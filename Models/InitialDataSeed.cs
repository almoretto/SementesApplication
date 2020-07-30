using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SementesApplication.Data;
using System;
using System.Linq;

namespace SementesApplication
{
    public class InitialDataSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SementesApplicationContext(
                serviceProvider.GetRequiredService<DbContextOptions<SementesApplicationContext>>()))
            {
                // Look for any States.
                if (context.State.Any())
                {
                    
                }
                else
                {
                    context.State.AddRange(
                        new State
                        {
                            UFAbreviation = "AC",
                            UFName = "Acre"
                        },
                        new State
                        {
                            UFAbreviation = "AL",
                            UFName = "Alagoas"
                        },
                        new State
                        {
                            UFAbreviation = "AP",
                            UFName = "Amapá"
                        },
                        new State
                        {
                            UFAbreviation = "AM",
                            UFName = "Amazonas"
                        },
                        new State
                        {
                            UFAbreviation = "BA",
                            UFName = "Bahia"
                        },
                        new State
                        {
                            UFAbreviation = "CE",
                            UFName = "Ceará"
                        },
                        new State
                        {
                            UFAbreviation = "DF",
                            UFName = "Distrito Federal"
                        },
                        new State
                        {
                            UFAbreviation = "ES",
                            UFName = "Espírito Santo"
                        },
                        new State
                        {
                            UFAbreviation = "GO",
                            UFName = "Goiás"
                        },
                        new State
                        {
                            UFAbreviation = "MA",
                            UFName = "Maranhão"
                        },
                        new State
                        {
                            UFAbreviation = "MT",
                            UFName = "Mato Grosso"
                        },
                        new State
                        {
                            UFAbreviation = "MS",
                            UFName = "Mato Grosso do Sul"
                        },
                        new State
                        {
                            UFAbreviation = "MG",
                            UFName = "Minas Gerais"
                        },
                        new State
                        {
                            UFAbreviation = "PA",
                            UFName = "Pará"
                        },
                        new State
                        {
                            UFAbreviation = "PB",
                            UFName = "Paraíba"
                        },
                        new State
                        {
                            UFAbreviation = "PR",
                            UFName = "Paraná"
                        },
                        new State
                        {
                            UFAbreviation = "PE",
                            UFName = "Pernambuco"
                        },
                        new State
                        {
                            UFAbreviation = "PI",
                            UFName = "Piauí"
                        },
                        new State
                        {
                            UFAbreviation = "RJ",
                            UFName = "Rio de Janeiro"
                        },
                        new State
                        {
                            UFAbreviation = "RN",
                            UFName = "Rio Grande do Norte"
                        },
                        new State
                        {
                            UFAbreviation = "RS",
                            UFName = "Rio Grande do Sul"
                        },
                        new State
                        {
                            UFAbreviation = "RO",
                            UFName = "Rondônia"
                        },
                        new State
                        {
                            UFAbreviation = "RR",
                            UFName = "Roraima"
                        },
                        new State
                        {
                            UFAbreviation = "SC",
                            UFName = "Santa Catarina"
                        },
                        new State
                        {
                            UFAbreviation = "SP",
                            UFName = "São Paulo"
                        },
                        new State
                        {
                            UFAbreviation = "SE",
                            UFName = "Sergipe"
                        },
                        new State
                        {
                            UFAbreviation = "TO",
                            UFName = "Tocantins"
                        });
                        context.SaveChanges();
                        
                }
                // Look for any States.
                if (context.State.Any())
                {

                }
                else
                {
                        
                }

            

            }
        }
    }
}
/*
                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M
                },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M
                    }
                );*/
