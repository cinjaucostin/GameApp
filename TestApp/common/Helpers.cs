namespace TestApp.common
{
    public class Helpers
    {
        //functiile incep mereu cu litera mare
        public static Dictionary<string, Dictionary<string, double>> LoadCharactersProperties(string path)
        {
            Dictionary<string, Dictionary<string, double>> properties = 
                new Dictionary<string, Dictionary<string, double>>();
            string[] splittedRow;
            string fighterAndProperty, fighter, property;
            double valueForProperty;
            //citirea din fisiere fara try..catch e moarte curata :D
            foreach (var row in File.ReadAllLines(path)) {
                splittedRow = row.Split('=');
                fighterAndProperty = splittedRow[0];
                fighter = fighterAndProperty.Split('.')[0];
                property = fighterAndProperty.Split('.')[1];
                valueForProperty = Convert.ToDouble(splittedRow[1]);
               
                if(!properties.ContainsKey(fighter))
                {
                    properties.Add(fighter, new Dictionary<string, double>());
                }
                properties[fighter].Add(property, valueForProperty);

            }

            return properties;
        }

            //no reason to keep dead code...

        }

}
