using System;

namespace Model
{
    public class Hardware
    {
        public string CurrentTime
        {
            get
            {
                return DateTime.Now.ToString();
            }
        }
    }
}
