// Grading ID: S7105
// Program #1
// Due date: 2/16/2021
// CIS 199-02
// This program calculates 
// total cost for a garden.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {

            //  VARIABLES


            const double FIRST_GARDEN_LABOR_COST = 50;      // additional $50 for labor when this is first garden
            const double LABOR_COST_PER_YARD = 3.25;        // cost of labor per yard
            const double FERTILIZER_COST_PER_YARD = 4.25;   // cost of fertilizer per yard
            const double NO_FERTILIZER_COST = 0;            // $0 cost when no fertilizer is needed
            const double SQ_FEET_PER_YARD = 9;              // square feet per yard for conversions
            const double SOIL_WASTE = 0.10;                 // addtional 10% charge for extra soil waste

            string gardenWidthInput,                        // user input for garden width
                   gardenLengthInput,                       // user input for garden length
                   soilPriceInput,                          // user input for price of soil
                   fertilizerInput,                         // user input for whether fertilizer is needed
                   firstGardenInput;                        // user input for whether this is their first garden

            double gardenWidth,                             // width of garden
                   gardenLength,                            // length of garden
                   soilPrice,                               // price of soil
                   sqYards,                                 // total square yards of garden

                   soilCost,                                // cost of soil
                   fertilizerCost,                          // cost of fertilizer
                   laborCostFirstGarden,                    // labor cost if first garden
                   laborCost,                               // labor cost if not first garden

                   totalNoFertilizer,                       // total cost if fertilizer not needed and not first garden
                   totalWithFertilizer,                     // total cost if fertilizer is needed and not first garden
                   totalFirstGardenNoFertilizer,            // total cost if fertilizer not needed and is first garden
                   totalFirstGardenWithFertilizer;          // total cost if fertilizer is needed and is first garden

               int fertilizerYN,                            // whether user needs fertilizer (1 = Yes, 0 = No)
                   firstGardenYN;                           // whether this is user's first garden (1 = Yes, 0 = No)


            // USER INPUT


            WriteLine("Welcome to the EZ-Garden and Landscaping Costs Estimator");      // title

            WriteLine();                                                                // for spacing

            Write("Enter the max width of the garden (in feet): ");                     // prompt for user to enter garden width
            gardenWidthInput = ReadLine();
            gardenWidth = double.Parse(gardenWidthInput);                               // convert input to double

            Write("Enter the max length of the garden (in feet): ");                    // prompt for user to enter garden length
            gardenLengthInput = ReadLine();
            gardenLength = double.Parse(gardenLengthInput);                             // convert input to double

            Write("Enter the soil price (per sq. yard): ");                             // prompt for user to enter price of soil
            soilPriceInput = ReadLine();
            soilPrice = double.Parse(soilPriceInput);                                   // convert input to double

            Write("Enter whether the fertilizer is needed (1 = YES, 0 = NO): ");        // prompt for user to specify whether fertilizer is needed
            fertilizerInput = ReadLine();
            fertilizerYN = int.Parse(fertilizerInput);                                  // convert input to int

            Write("Is this the first garden? (1 = YES, 0 = NO): ");                     // prompt for user to specify whether this is first garden
            firstGardenInput = ReadLine();
            firstGardenYN = int.Parse(firstGardenInput);                                // convert input to int

            WriteLine();                                                                // for spacing


            // VARIABLE CALCULATIONS


            sqYards = (gardenWidth * gardenLength) / SQ_FEET_PER_YARD;                              // calculation of square yards
            soilCost = (soilPrice * sqYards) + (soilPrice * sqYards * SOIL_WASTE);                  // calculation of soil cost
            fertilizerCost = (sqYards * FERTILIZER_COST_PER_YARD);                                  // calculation of fertilizer cost
            laborCostFirstGarden = (sqYards * LABOR_COST_PER_YARD) + FIRST_GARDEN_LABOR_COST;       // calculation of labor if first garden
            laborCost = sqYards * LABOR_COST_PER_YARD;                                              // calculation of labor if not first garden


            totalNoFertilizer = soilCost + NO_FERTILIZER_COST + laborCost;                          // calculation of total if not first garden with no fertilizer cost
            totalWithFertilizer = soilCost + fertilizerCost + laborCost;                            // calculation of total if not first garden with fertilizer cost

            totalFirstGardenNoFertilizer = soilCost + NO_FERTILIZER_COST + laborCostFirstGarden;    // calculation of total if first garden with no fertilizer cost
            totalFirstGardenWithFertilizer = soilCost + fertilizerCost + laborCostFirstGarden;      // calculation of total if first garden with fertilizer cost


            // DISPLAY TOTALS


            WriteLine($"Sq. Yards Needed: {sqYards,5:F1}");                             // displays total square yards

            WriteLine($"Soil Cost: {soilCost,15:C2}");                                  // displays soil cost

            if (fertilizerYN == 1)                                                      // displays fertilizer cost if needed
                WriteLine($"Fertilizer Cost: {fertilizerCost,9:C2}");
            else                                                                        // displays $0.00 cost if fertilizer not needed
                WriteLine($"Fertilizer Cost: {NO_FERTILIZER_COST,7:C2}");               

            if (firstGardenYN == 1)                                                     // displays labor cost if first garden
                WriteLine($"Labor Cost: {laborCostFirstGarden,14:C2}");
            else                                                                        // displays labor cost if not first garden
                WriteLine($"Labor Cost: {laborCost,14:C2}");

            // POTENTIAL TOTAL COSTS

            if (fertilizerYN == 0 && firstGardenYN == 0)                                // displays total cost if no fertilizer is needed and not first garden
                    WriteLine($"Total Cost: {totalNoFertilizer,14:C2}");

            if (fertilizerYN == 1 && firstGardenYN == 0)                                // displays total cost if fertilizer is needed and not first garden
                WriteLine($"Total Cost: {totalWithFertilizer,16:C2}");

            if (fertilizerYN == 0 && firstGardenYN == 1)                                // displays total cost if no fertilizer is needed and is first garden
                WriteLine($"Total Cost: {totalFirstGardenNoFertilizer,14:C2}");

            if (fertilizerYN == 1 && firstGardenYN == 1)                                // displays total cost if fertilizer is needed and is first garden
                WriteLine($"Total Cost: {totalFirstGardenWithFertilizer,16:C2}");

            WriteLine();                                                                // for spacing
            ReadLine();
        }
    }
}
