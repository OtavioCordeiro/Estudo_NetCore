using System;

namespace Greetings
{
    public class RandomGreeting : IGreeting
    {
        public string GetMessageOfDay()
        {
            Random random = new Random();
            int x = random.Next(1, 4);

            string greetings;
            switch (x)
            {
                case 1:
                    greetings = "Bom Dia";
                    break;

                case 2:
                    greetings = "Bom Tarde";
                    break;

                case 3:
                    greetings = "Bom Noite";
                    break;

                default:
                    greetings = "Inesperado";
                    break;
            }

            return greetings;
        }
    }
}
