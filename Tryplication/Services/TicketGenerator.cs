using System;
using System.Collections.Generic;
using Tryplication.Models;

namespace Tryplication.Services
{
    public class TicketGenerator : ITicketGenerator
    {
        public IEnumerable<Ticket> GenerateTickets()
        {
            List<Employee> employees = GenerateEmployees();
            List<Ticket> result = new List<Ticket>
            {
                new Ticket()
                {
                    Id = 1,
                    TicketName = "TIK-001",
                    TicketComplexity = Constants.Complxity.High,
                    AssignedEmplyee = employees[0]
                },
                new Ticket()
                {
                    Id = 2,
                    TicketName = "TIK-002",
                    TicketComplexity = Constants.Complxity.Critical,
                    AssignedEmplyee = employees[1]

                },
                new Ticket()
                {
                    Id = 3,
                    TicketName = "TIK-003",
                    TicketComplexity = Constants.Complxity.Low,
                    AssignedEmplyee = employees[2]

                },
                new Ticket()
                {
                    Id = 4,
                    TicketName = "TIK-004",
                    TicketComplexity = Constants.Complxity.Mid,
                    AssignedEmplyee = employees[3]
                },
                new Ticket()
                {
                    Id = 5,
                    TicketName = "TIK-005",
                    TicketComplexity = Constants.Complxity.Low,
                    AssignedEmplyee = employees[0]
                }
            };

            return result;
        }

        private List<Employee> GenerateEmployees()
        {
            List<Employee> result = new List<Employee>
            {
                new Employee()
                {
                    Id = 1,
                    Name = "John",
                    Position = Constants.Posisiton.JuniorDeveloper,
                    PhoneNumber = "2020202001"
                },

                new Employee()
                {
                    Id = 2,
                    Name = "Matt",
                    Position = Constants.Posisiton.SeniorDeveloper,
                    PhoneNumber = "1010101001"
                },

                new Employee()
                {
                    Id = 3,
                    Name = "Tim",
                    Position = Constants.Posisiton.MiddleDeveloper,
                    PhoneNumber = "03030330301"
                },

                new Employee()
                {
                    Id = 4,
                    Name = "Terrance",
                    Position = Constants.Posisiton.JuniorDeveloper,
                    PhoneNumber = "02222000001"
                },

                new Employee()
                {
                    Id = 5,
                    Name = "Tadokoro",
                    Position = Constants.Posisiton.SeniorDeveloper,
                    PhoneNumber = "012321421301"
                }
            };
            return result;
        }
    }
}