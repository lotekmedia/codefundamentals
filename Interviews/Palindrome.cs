using System;
using System.Text;

namespace Palindrome{

    public class PalindromeTester{
    
        public string stringToTest { get; set; }

        public bool Test(){
            
            int stringLength = stringToTest.Length -1;
            int index = 0;
            bool isPalindrome = true;
            int lengthToCheck = stringLength / 2;

            if (String.IsNullOrEmpty(stringToTest) || stringLength < 2)
            {
                return isPalindrome;
            }
            
            //Check If Odd Number Length
            if (stringLength % 2 != 0)
            {
                lengthToCheck = Convert.ToInt16(Math.Floor(Convert.ToDecimal(lengthToCheck)));
            }

            while (index < lengthToCheck && isPalindrome)
            {
                if (stringToTest[index] != stringToTest[stringLength - index])
                {
                    isPalindrome = false;
                }
                index++;
            }
            return isPalindrome;
        }
    }
}