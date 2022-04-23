//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;
using System.Linq;
using Full_GRASP_And_SOLID.Library;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
        }
        // nuevo:
        // Por Expert le asigno al a clase Recipie la responsabilidad de calcular las sumatorias correspondientes
        // a la letra del ejercicio (Esta clase tiene acceso a todos los datos necesarios para realizar dicha labor). 
        public void GetSum()
        {
            double SumUnitCost = 0, SumCostHora = 0, SumTotal = 0;
            foreach (Step step in this.steps)
            {
                SumUnitCost = SumUnitCost + (step.Input.UnitCost * step.Quantity);
                SumCostHora = SumCostHora + (step.Equipment.HourlyCost * (step.Time/60));
                SumTotal = SumUnitCost + SumCostHora;       
            }
            Console.WriteLine($"La suma del costo unitario de los productos es: {SumUnitCost}");
            Console.WriteLine($"La suma del costo de uso x hora de todo el equipamiento es: {SumCostHora}");
            Console.WriteLine($"El costo total es: {SumTotal}");
        }
        //
    }
}