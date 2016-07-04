using System;
using System.Security.Cryptography;

//------------------------------------------------------------------------------------------------------
// <copyright file="RandomNumberGenerator.vb" company="">
// Copyright (c) Rachie Holdings Ltd. All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------------
// http://msdn.microsoft.com/en-us/library/system.security.cryptography.rngcryptoserviceprovider(v=VS.90).aspx
namespace WebJobUniUtils {
    public class RandomGenerator {


        /// <summary>
        /// Return random number.  Value is not truly random!  to see this, perform FOR LOOP on function.
        /// 
        /// See RandomNumberGenerator.vb for better version.
        /// </summary>
        /// <param name="MaxNumber"></param>
        /// <param name="MinNumber"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int RandomNumber(int MaxNumber, int MinNumber = 0) {

            //initialize random number generator
            Random r = new Random();

            //if passed incorrect arguments, swap them
            //can also throw exception or return 0
            if (MinNumber > MaxNumber) {
                int t = MinNumber;
                MinNumber = MaxNumber;
                MaxNumber = t;
            }

            return r.Next(MinNumber, MaxNumber);
        }

        /// <summary>
        /// Return random number.  Value is not truly random!  to see this, perform FOR LOOP on function.
        /// 
        /// See RandomNumberGenerator.vb for better version.
        /// </summary>
        /// <param name="MaxNumber"></param>
        /// <param name="MinNumber"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int RandomNumber2(int MaxNumber, int MinNumber = 0) {

            return NextInt(MinNumber, MaxNumber);
        }


        /// <summary>
        /// Return random boolean true or false
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool RandomBoolean() {
            dynamic randInt = RandomNumber(0, 1);
            if (randInt == 0)
                return false;

            else // (randInt == 1) 
                return true;

        }


        // Main method.
        public static void Main() {
                const int totalRolls = 25000;
                int[] results = new int[6];

                // Roll the dice 25000 times and display
                // the results to the console.
                int x = 0;
                for (x = 0; x <= totalRolls; x++) {
                    byte roll = RollDice(System.Convert.ToByte(results.Length));
                    results[(roll - 1)] += 1;
                }
                int i = 0;

                while (i < results.Length) {
                    Console.WriteLine("{0}: {1} ({2:p1})", i + 1, results[i], System.Convert.ToDouble(results[i]) / System.Convert.ToDouble(totalRolls));
                    i += 1;
                }

            }


            // This method simulates a roll of the dice. The input parameter is the
            // number of sides of the dice.
            public static byte RollDice(byte numberSides) {
                if (numberSides <= 0) {
                    throw new ArgumentOutOfRangeException("NumSides");
                }
                // Create a new instance of the RNGCryptoServiceProvider.
                RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
                // Create a byte array to hold the random value.
                byte[] randomNumber = new byte[1];
                do {
                    // Fill the array with a random value.
                    rngCsp.GetBytes(randomNumber);
                } while (!IsFairRoll(randomNumber[0], numberSides));
                // Return the random number mod the number
                // of sides.  The possible values are zero-
                // based, so we add one.
                return System.Convert.ToByte(randomNumber[0] % numberSides + 1);

            }


            private static bool IsFairRoll(byte roll, byte numSides) {
                // There are MaxValue / numSides full sets of numbers that can come up
                // in a single byte.  For instance, if we have a 6 sided die, there are
                // 42 full sets of 1-6 that come up.  The 43rd set is incomplete.
                int fullSetsOfValues = Byte.MaxValue / numSides;

                // If the roll is within this range of fair values, then we let it continue.
                // In the 6 sided die case, a roll between 0 and 251 is allowed.  (We use
                // < rather than <= since the = portion allows through an extra 0 value).
                // 252 through 255 would provide an extra 0, 1, 2, 3 so they are not fair
                // to use.
                return roll < numSides * fullSetsOfValues;

            }
            //IsFairRoll

   /// <summary>
            /// Community content.
            /// http://msdn.microsoft.com/en-us/library/system.security.cryptography.rngcryptoserviceprovider(v=VS.90).aspx
            /// </summary>
            /// <param name="min"></param>
            /// <param name="max"></param>
            /// <returns></returns>
            /// <remarks></remarks>
            public static int NextInt(int min, int max) {
                dynamic rng = new RNGCryptoServiceProvider();
                byte[] buffer = new byte[5];
                rng.GetBytes(buffer);
                int result = BitConverter.ToInt32(buffer, 0);
                return new Random(result).Next(min, max);
            }


        }//class
    }//namespace


