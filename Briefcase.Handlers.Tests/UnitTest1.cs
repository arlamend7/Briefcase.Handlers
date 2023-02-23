using Briefcase.Handlers.Handleds.Interfaces;
using Briefcase.Handlers.Injection;
using Briefcase.Handlers.Interfaces;
using Briefcase.System.Asyncronuos;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using static Briefcase.Handlers.Tests.Data.DataTest;

namespace Briefcase.Handlers.Tests
{
    public class UnitTest1
    {

        public class Test
        {
            public string Name { get; set; }
        }
        [Fact]
        public void Test4()
        {
            var teste = Interactable<Test>.Create();


            teste.Append(Create("test"));
            teste.Append(Create("test2"));
            teste.Append(Create("test3"));
            teste.Append(Create("test4"));

            var element = teste.ElementAt(2);

            Func<Test> Create(string name)
            {
                return () =>
                {
                    return new Test { Name = name };
                };
            }
        }
        [Fact]
        public void TestClear()
        {
            List<Person> persons = new List<Person>();

            var teste = Enumerable.Range(0, 100).Select(x =>
            {
                var person = new Person()
                {
                    Id = Guid.NewGuid(),
                };

                var request = new PersonInsertRequest()
                {
                    CompleteName = $"Arlan dos Santos Franklin Mendes{x}",
                    Birthdate = "1998-10-31"
                };

                person.FirstName = request.CompleteName.Split(' ').First();
                person.LastName = request.CompleteName.Split(' ').Last();
                person.CompleteName = request.CompleteName;
                person.Age = PersonMapperHandlerConfiguration.GetAgeByBirthdate(PersonMapperHandlerConfiguration.Convert(request.Birthdate));

                return person;
            });

            teste.ToList();
            teste.ToList();
        }
        [Fact]
        public void TestA()
        {

            var configurationBuilder = new PersonHandlerConfiguration()
                                      .Builder();

            configurationBuilder.SetMapper(new PersonMapperHandlerConfiguration());

            IHandlerCollection handlers = IHandlerCollection.Instanciate();

            handlers.Add(configurationBuilder.Build());

            List<Person> persons = new List<Person>();

            var canStop = Enumerable.Range(0, 100000).Select(x =>
            {
                using var operation = handlers.Create<Person>();
                return operation.EditBy(new PersonInsertRequest()
                {
                    CompleteName = $"Arlan dos Santos Franklin Mendes{x}",
                    Birthdate = "1998-10-31"
                });
            }).Select(x => x.Result)
            .ToList();
        }
        [Fact]
        public void Testb()
        {
            var configurationBuilder = new PersonHandlerConfiguration()
                                      .Builder();

            configurationBuilder.SetMapper(new PersonMapperHandlerConfiguration());

            IHandlerCollection handlers = IHandlerCollection.Instanciate();

            handlers.Add(configurationBuilder.Build());

            List<Person> persons = new List<Person>();

            IHandlerOperation<Person> operation = handlers.Create<Person>();

            persons
                .AddRange(Enumerable.Range(0, 100000).AsParallel().Select(x =>
                {
                    return handlers.Create<Person>()
                        .EditBy(new PersonInsertRequest()
                        {
                            CompleteName = $"Arlan dos Santos Franklin Mendes{x}",
                            Birthdate = "1998-10-31"
                        }).Result;
                }));
        }
        [Fact]
        public void TestC()
        {
            var configurationBuilder = new PersonHandlerConfiguration()
                                      .Builder();

            configurationBuilder.SetMapper(new PersonMapperHandlerConfiguration());

            IHandlerCollection handlers = IHandlerCollection.Instanciate();

            handlers.Add(configurationBuilder.Build());

            List<Person> persons = new List<Person>();

            IHandlerOperation<Person> operation = handlers.Create<Person>();

            foreach (var item in Enumerable.Range(0, 100000))
            {
                using (operation)
                {
                    operation.EditBy(new PersonInsertRequest()
                    {
                        CompleteName = $"Arlan dos Santos Franklin Mendes{item}",
                        Birthdate = "1998-10-31"
                    }).Any(x => x.IsError);

                }
            }
        }
        [Fact]
        public void Test1()
        {
            var configurationBuilder = new PersonHandlerConfiguration()
                                      .Builder();

            configurationBuilder.SetMapper(new PersonMapperHandlerConfiguration());

            IHandlerCollection handlers = IHandlerCollection.Instanciate();

            handlers.Add(configurationBuilder.Build());

            IHandler<Person> personHandler = handlers.Get<Person>();

            using IHandlerOperation<Person> operation = personHandler.Create();

            var id = Guid.NewGuid();
            operation.Edit(x =>
            {
                x.FirstName = "Test";
                x.LastName = "Test";
                x.Age = 1;
            });

            operation.Edit(x =>
            {
                x.Id = id;
                x.FirstName = "Test2";
                x.LastName = "Test2";
                x.Age = 2;
            });

            operation.NotExecutedLength.Should().Be(6);
            operation.ExecutedLength.Should().Be(0);

            string[] properties = new string[3] { "Age", "LastName", "FirstName" };

            foreach (var property in properties)
            {
                //operation.For(property).NotExecutedLength.Should().Be(2);

            }

            operation.NotExecutedLength.Should().Be(6);
            operation.ExecutedLength.Should().Be(0);

            IHandledChange change = operation.GetChangeFor(x => x.FirstName);

            change.Should().NotBeNull();
            change.Value.Should().Be("Test2");

            operation.NotExecutedLength.Should().Be(5);
            operation.ExecutedLength.Should().Be(1);

            operation.GetChangeFor(x => x.LastName).Should().NotBeNull();
            operation.GetChangeFor(x => x.Age).Should().NotBeNull();

            operation.NotExecutedLength.Should().Be(3);
            operation.ExecutedLength.Should().Be(3);

            var person = operation.Result;

            operation.NotExecutedLength.Should().Be(3);
            operation.ExecutedLength.Should().Be(3);

            person.Should().NotBeNull();
            person.Id.Should().NotBeNull();
            person.Id.Should().NotBe(id);
            person.FirstName.Should().Be("Test2");
            person.LastName.Should().Be("Test2");
            person.Age.Should().Be(2);
        }


        [Fact]
        public void Test2()
        {
            var service = new ServiceCollection()
                                .UseHandlers(this.GetType().Assembly);
            var serviceProvider = service.BuildServiceProvider();

            IHandler handlers = serviceProvider.GetService<IHandler>();

            handlers.Should().NotBeNull();

            using var operation = handlers.Create<Person>();

            operation.Result.Id.Should().NotBeNull();
            operation.Should().NotBeNull();
        }

        [Fact]
        public void Test3()
        {
            IServiceCollection service = new ServiceCollection()
                    .UseHandlers(GetType().Assembly);
            ServiceProvider serviceProvider = service.BuildServiceProvider();

            IHandler handlers = serviceProvider.GetService<IHandler>();

            using IHandlerOperation<TesteEntity> operation = handlers.Create<TesteEntity>();

            operation.Edit(x =>
            {
                x.Id = Guid.NewGuid();
                x.Name = "Arlan";
                x.LastName = "Mendes";
            });

            operation.Should().NotBeNull();
        }

        public class TesteEntity
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
        }
    }
}