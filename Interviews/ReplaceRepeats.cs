using System;
using System.Text;

namespace Interviews
{
    public class ReplaceRepeats
    {
        public string StringToUpdate { get; set; }

        public ReplaceRepeats(string currentString)
        {
            this.StringToUpdate = currentString;
        }

        public string Execute()
        {

            if (countCompression() >= this.StringToUpdate.Length)
            {
                return this.StringToUpdate;
            }
            int currentCount = 1;
            char currentChar = this.StringToUpdate[0];
            StringBuilder sb = new StringBuilder();
            sb.Append(currentChar);
            for (int i = 1; i < this.StringToUpdate.Length; i++)
            {
                if (currentChar == this.StringToUpdate[i])
                {
                    currentCount++;
                }
                else
                {
                    sb.Append(currentCount);
                    currentChar = this.StringToUpdate[i];
                    sb.Append(currentChar);
                    currentCount = 1;
                }
            }
            sb.Append(currentCount);
            return sb.ToString();
        }

        private int countCompression()
        {
            if (String.IsNullOrEmpty(this.StringToUpdate))
            {
                return 0;
            }
            int size = 0;
            int count = 1;
            char last = this.StringToUpdate[0];
            for (int i = 1; i < this.StringToUpdate.Length; i++)
            {
                if (this.StringToUpdate[i] == last)
                {
                    count++;
                }
                else
                {
                    last = this.StringToUpdate[i];
                    size += 1 + count.ToString().Length;
                    count = 1;
                }
            }
            size += 1 + count.ToString().Length;
            return size;
        }
    }

}