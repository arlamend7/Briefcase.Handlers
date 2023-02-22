using Briefcase.Handlers.Builder.Interfaces;
using Briefcase.Handlers.Customizes;
using Briefcase.Handlers.Customizes.Interfaces;

namespace Briefcase.Handlers.Tests.Data
{
    public class DataTest
    {
        public class Person
        {
            public Guid? Id { get; set; }
            public int Age { get; set; }
            public string Name { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string CompleteName { get; set; }
            public Person()
            {

            }
        }
        public class PersonInsertRequest
        {
            public string CompleteName { get; set; }
            public string Birthdate { get; set; }
        }

        public class PersonHandlerConfiguration : HandlerCustomConfigutation<Person>
        {
            public override void ConfigureRules(IHandlerConfigurationBuilder<Person> builder)
            {
                builder
                   .Ignore(x => x.Id)
                   .For(x => x.FirstName, builder =>
                   {
                       return builder
                               .ThrowErrorIfValueIs("caleb", "O nome não pode ser Caleb")
                               .ThrowErrorIfValueIs("arlan", "O nome não pode ser arlan")
                               .ThrowErrorIfValue(prop => prop.EndsWith("zinho"), prop => $"o nome {prop} finaliza com zinho, isto não é permitido!")
                               .Conclude;
                   })
                   .For(x => x.Age, builder =>
                   {
                       return builder
                                   .IgnoreIfValueIs(0)
                                   .Conclude;
                   });
            
            }

            public override void OnCreate(Person value)
            {
                value.Id = Guid.NewGuid();
            }
        }
        public class PersonMapperHandlerConfiguration : IHandlerMapperConfigurarion<Person, PersonInsertRequest>
        {
            public void ConfigureMapper(IMapperConfigurationBuilder<Person, PersonInsertRequest> builder)
            {
                builder
                .For(person => person.Age,
                    propertyMapper =>
                {
                    return propertyMapper
                                .MapFrom(request => request.Birthdate)
                                .IgnoreDefaultValue()
                                .ConvertUsing(Convert, "data não é valida para conversão")
                                .ConvertUsing(GetAgeByBirthdate, "a data é maior que hoje");
                })
                .For(person => person.FirstName,
                    propertyMapper =>
                {
                    return propertyMapper
                                .MapFrom(request => request.CompleteName)
                                .ConvertUsing(x => x.Split(" ").First());
                })
                .For(person => person.LastName,
                    propertyMapper =>
                {
                    return propertyMapper
                                .MapFrom(request => request.CompleteName)
                                .IgnoreDefaultValue()
                                .ConvertUsing(x => x.Split(" ").Last());
                })
                .For(person => person.CompleteName,
                    propertyMapper =>
                {
                    return propertyMapper
                                .MapFrom(request => request.CompleteName)
                                .IgnoreDefaultValue()
                                .UseSameValue;
                });
            }

            public static DateTime Convert(string dataString)
            {
                return DateTime.Parse(dataString);
            }

            public static int GetAgeByBirthdate(DateTime data)
            {
                return (int)Math.Floor((DateTime.Now - data).TotalDays / 365);
            }
        }
    }
}
