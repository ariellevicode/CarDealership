using CarDealership.CarClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal interface IPrompter
{
    Car AskUserForCarDetails(string actionType);
    string AskUserForCarId(); 
}
