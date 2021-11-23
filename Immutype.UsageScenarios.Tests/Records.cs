﻿// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable RedundantNameQualifier
namespace Immutype.UsageScenarios.Tests
{
    using System.Collections.Immutable;
    using Shouldly;
    using Xunit;

    // $visible=true
    // $tag=1 Basics
    // $priority=01
    // $description=Records
    // {
    [Immutype.Target]
    internal record Person(string Name, bool HasPassport = true, int Age = 0, ImmutableArray<Person> Friends = default);
    
    public class Records
    {
        [Fact]
        public void Run()
        {
            var john = new Person("John", false, 15)
                .WithFriends(
                    new Person("David").WithAge(16),
                    new Person("James").WithAge(17)
                        .WithFriends(new Person("Tyler").WithAge(16)));
                
            john.Friends.Length.ShouldBe(2);

            john = john.WithAge(16).WithDefaultHasPassport();
            john.Age.ShouldBe(16);
            john.HasPassport.ShouldBeTrue();

            john = john.AddFriends(
                new Person("Daniel").WithAge(17),
                new Person("Sophia").WithAge(18));
            
            john.Friends.Length.ShouldBe(4);
        }
    }
    // }
}
