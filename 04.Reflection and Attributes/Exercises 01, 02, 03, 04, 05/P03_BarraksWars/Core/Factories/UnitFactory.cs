namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using _03BarracksFactory.Models.Units;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            // Problem 3:
            Assembly assebmly = Assembly.GetExecutingAssembly();
            Type model = assebmly.GetTypes().FirstOrDefault(t => t.Name == unitType);

            if (model== null)
            {
                throw new ArgumentException("Unvalid unit type");
            }

            // za check дали модела интерп IUnit interface:
            //if(model.GetInterfaces().Any(i=>i==typeof(IUnit)))
            if ( !typeof(IUnit).IsAssignableFrom(model)) // т.е. в пром IUnit, мога ли да запиша model. /also has IsAssignableFrom/
            {
                throw new ArgumentException($"{unitType} is not a Unit Type!");
            }

            IUnit unit = (IUnit)Activator.CreateInstance(model);
            return unit;

            //// Var.2: - why does nor works?????????????????? - NO !!!
            //var type = Type.GetType("_03BarracksFactory.Models.Units." + unitType);
            //var classes = type.GetConstructors();
            //var targetClass  =(IUnit)classes.First(c => c.Name == unitType);
            //return targetClass;

            // Var.3:
            //switch (unitType)
            //{
            //    case "Archer":
            //        IUnit archer = new Archer();
            //        return archer;
            //    case "Pikeman":
            //        IUnit pikeman = new Pikeman();
            //        return pikeman;
            //    case "Swordsman":
            //        IUnit swordsMan = new Swordsman();
            //        return swordsMan;
            //    default:
            //        throw new ArgumentException("Incorrect Unit type!");
            //}
        }
    }
}
