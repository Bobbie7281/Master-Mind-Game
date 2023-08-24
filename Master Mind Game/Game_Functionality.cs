﻿namespace Master_Mind_Game
{
    internal class Game_Functionality
    {
        List<int> secretCodes = new();
        List<int> result = new();
        List<int> duplicatesValueGuess = new();
        List<int> duplicatesValueSecretCode = new();
        List<int> duplicatesAmountGuess = new();
        List<int> duplicatesAmountSecretCode = new();
        List<int> guessDuplicateIndexesOne = new();
        List<int> guessDuplicateIndexesTwo = new();
        List<int> secretCodeDuplicateIndexesOne = new();
        List<int> secretCodeDuplicateIndexesTwo = new();

        int rowNumber = 0;

        int firstNum = 0;
        int secondNum = 0;
        int thirdNum = 0;
        int fourthNum = 0;

        Label ?resOne;
        Label ?resTwo;
        Label ?resThree;
        Label ?resFour;

        int duplicatesMatchDetected;
        bool duplicatesInBothCodes;
        readonly Random randomNum = new();

        public List<int> SecretCodes
        {
            set { secretCodes = value; }
            get { return secretCodes; }
        }
        private List<int> Result
        {
            set { result = value; }
            get { return result; }
        }
        private List<int> DuplicatesValueGuess
        {
            set { duplicatesValueGuess = value; }
            get { return duplicatesValueGuess; }
        }
        private List<int> DuplicatesValueSecretCode
        {
            set { duplicatesValueSecretCode = value; }
            get { return duplicatesValueSecretCode; }
        }
        private List<int> DuplicatesAmountGuess
        {
            set { duplicatesAmountGuess = value; }
            get { return duplicatesAmountGuess; }
        }
        private List<int> DuplicatesAmountSecretCode
        {
            set { duplicatesAmountSecretCode = value; }
            get { return duplicatesAmountSecretCode; }
        }
        private List<int> GuessDuplicateIndexesOne
        {
            set { guessDuplicateIndexesOne = value; }
            get { return guessDuplicateIndexesOne; }
        }
        private List<int> GuessDuplicateIndexesTwo
        {
            set { guessDuplicateIndexesTwo = value; }
            get { return guessDuplicateIndexesTwo; }
        }
        private List<int> SecretCodeDuplicateIndexesOne
        {
            set { secretCodeDuplicateIndexesOne = value; }
            get { return secretCodeDuplicateIndexesOne; }
        }
        private List<int> SecretCodeDuplicateIndexesTwo
        {
            set { secretCodeDuplicateIndexesTwo = value; }
            get { return secretCodeDuplicateIndexesTwo; }
        }
        private int DuplicatesMatchDetected
        {
            set { duplicatesMatchDetected = value; }
            get { return duplicatesMatchDetected; }
        }
        private bool DuplicatesInBothCodes
        {
            set { duplicatesInBothCodes = value; }
            get { return duplicatesInBothCodes; }
        }

        public int RowNumber
        {
            set { rowNumber = value; }
            get { return rowNumber; }
        }
        public int FirstNum
        {
            set { firstNum = value; }
            get { return firstNum; }
        }
        public int SecondNum
        {
            set { secondNum = value; }
            get { return secondNum; }
        }
        public int ThirdNum
        {
            set { thirdNum = value; }
            get { return thirdNum; }
        }
        public int FourthNum
        {
            set { fourthNum = value; }
            get { return fourthNum; }
        }

        public Label ResOne
        { 
            set { resOne = value; } 
            get { return resOne; }
        }
        public Label ResTwo
        { 
            set { resTwo = value; }
            get { return resTwo; }
        }
        public Label ResThree
        {
            set { resThree = value; }
            get { return resThree; }
        }
        public Label ResFour
        {
            set { resFour = value; }
            get { return resFour; }
        }

        /// <summary>
        /// If the computer is the code maker, the code is autogenerated when the Game form loads
        /// The code is saved into a list so that every individual number is checked with the users guess. 
        /// </summary>
        public void SetSecretCode()
        {
            SecretCodes.Clear();
            for (int i = 0; i < 4; i++)
            {
                SecretCodes.Add(randomNum.Next(1, 8));
            }
            /*SecretCodes.Add(3);
            SecretCodes.Add(1);
            SecretCodes.Add(3);
            SecretCodes.Add(1);*/
        }
        /// <summary>
        /// Checks the player's guess with the random number
        /// </summary>
        /// <param name="guess"></param>
        /// <returns> Returns the result as a list </returns>
        public List<int> CheckGuess(List<int> guess)
        {
            int index = -1;
            Result.Clear();

            var updatedGuess = CheckForDuplicateNumbers(guess);

            for (int i = 0; i < updatedGuess.Count; i++)
            {
                bool matchingValueAndIndex = false;
                bool matchingValueNotIndex = false;

                for (int j = 0; j < SecretCodes.Count; j++)
                {
                    if (updatedGuess[i] != 0)
                    {
                        if (updatedGuess[i] == SecretCodes[j])
                        {
                            if (i == j)
                            {
                                index++;
                                matchingValueAndIndex = true;
                                Result.Add(1);
                                break;
                            }
                            else if (i != j)
                            {
                                matchingValueNotIndex = true;
                            }
                        }
                    }
                }
                if (matchingValueNotIndex && !matchingValueAndIndex)
                {
                    index++;
                    Result.Add(0);
                }

            }

            return Result;
        }
        private List<int> CheckForDuplicateNumbers(List<int> guess)
        {
            bool sameNumbersDetected = false;
            bool firstList = true;
            int totalDuplicates = 0;


            GuessDuplicateIndexesOne.Clear();
            GuessDuplicateIndexesTwo.Clear();
            SecretCodeDuplicateIndexesOne.Clear();
            SecretCodeDuplicateIndexesTwo.Clear();

            //Lists all the duplicate numbers in the player's guess.
            DuplicatesValueGuess = guess.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();
            //Lists all the duplicate numbers in the secret Code.
            DuplicatesValueSecretCode = SecretCodes.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();
            //Lists the amount of duplicate numbers in the player's guess.
            DuplicatesAmountGuess = guess.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(g => g.Count())
               .ToList();
            //Lists the amount of duplicate numbers in the secret Code.
            DuplicatesAmountSecretCode = SecretCodes.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(g => g.Count())
               .ToList();


            List<List<int>> duplicateValuesLists = new List<List<int>>()
            {
                DuplicatesValueGuess,
                DuplicatesValueSecretCode,
            };

            for (int x = 0; x < duplicateValuesLists.Count; x++)
            {
                for (int i = 0; i < duplicateValuesLists[x].Count; i++)
                {
                    if (firstList && duplicateValuesLists[0].Count > 0)
                    {
                        sameNumbersDetected = true;
                        totalDuplicates++;
                        for (int j = 0; j < guess.Count; j++)
                        {
                            if (guess[j] == DuplicatesValueGuess[i])
                            {
                                if (totalDuplicates == 1)
                                {
                                    GuessDuplicateIndexesOne.Add(j);
                                }
                                else
                                {
                                    GuessDuplicateIndexesTwo.Add(j);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (duplicateValuesLists[1].Count > 0)
                        {
                            sameNumbersDetected = true;
                            totalDuplicates++;
                            for (int j = 0; j < SecretCodes.Count; j++)
                            {
                                if (SecretCodes[j] == DuplicatesValueSecretCode[i])
                                {
                                    if (totalDuplicates == 1)
                                    {
                                        SecretCodeDuplicateIndexesOne.Add(j);
                                    }
                                    else
                                    {
                                        SecretCodeDuplicateIndexesTwo.Add(j);
                                    }
                                }
                            }
                        }
                    }
                }
                firstList = false;
                totalDuplicates = 0;
            }
            if (sameNumbersDetected)
            {
                var updatedGuess = GetResultsForDuplicateValues(guess);

                //The following should only be accessed when both the guess and secret code contain duplicate values.
                if (DuplicatesInBothCodes)
                {
                    if (DuplicatesMatchDetected != DuplicatesValueGuess.Count)
                    {
                        updatedGuess = CheckNonMatchingDuplicatesForSingles(guess);
                        return updatedGuess;
                    }
                    else
                    {
                        return updatedGuess;
                    }
                }
                else
                {
                    return updatedGuess;
                }
            }
            else
            {
                return guess;
            }
        }
        private List<int> GetResultsForDuplicateValues(List<int> guess)
        {
            int totalDuplicates = 0;

            //If there are duplicates in the guess but there aren't any duplicates in the secret code,
            //the code will check if the secret code contains a number with the same value as the duplicate,
            //if it doesn't, the duplicatesDetected will be set to false as won't make any difference   
            if (DuplicatesValueGuess.Count > 0 && DuplicatesValueSecretCode.Count == 0)
            {
                DuplicatesInBothCodes = false;
                for (int x = 0; x < DuplicatesValueGuess.Count; x++)
                {
                    totalDuplicates++;
                    if (SecretCodes.Contains(DuplicatesValueGuess[x]))//if SecretCodes contains the value in DuplicatesValuesGuess
                    {
                        int secretCodeIndex = SecretCodes.IndexOf(DuplicatesValueGuess[x]);//Get the index of the number in the secret Code

                        if (totalDuplicates == 1)
                        {
                            if (GuessDuplicateIndexesOne.Contains(secretCodeIndex))//If GuessDuplicateIndexes contains the same index of the number in the secret code
                            {
                                Result.Add(1);
                            }
                            else
                            {
                                Result.Add(0);
                            }
                        }
                        else
                        {
                            if (GuessDuplicateIndexesTwo.Contains(secretCodeIndex))//If GuessDuplicateIndexes contains the same index of the number in the secret code
                            {
                                Result.Add(1);
                            }
                            else
                            {
                                Result.Add(0);
                            }
                        }
                        for (int i = 0; i < guess.Count; i++)
                        {
                            if (guess[i] == DuplicatesValueGuess[x])
                            {
                                guess[i] = 0;
                            }
                        }
                    }
                }
            }
            /*If there are duplicates in the secret code but there aren't any duplicates in the guess code,
            the code will check if the guess code contains a number with the same value as the duplicate,
            if it doesn't, the duplicatesDetected will be set to false as won't make any difference */
            else if (DuplicatesValueSecretCode.Count > 0 && DuplicatesValueGuess.Count == 0)
            {
                DuplicatesInBothCodes = false;
                for (int x = 0; x < DuplicatesValueSecretCode.Count; x++)
                {
                    totalDuplicates++;
                    if (guess.Contains(DuplicatesValueSecretCode[x]))
                    {  
                        int guessCodeIndex = guess.IndexOf(DuplicatesValueSecretCode[x]);

                        if (totalDuplicates == 1)
                        {
                            if (SecretCodeDuplicateIndexesOne.Contains(guessCodeIndex))
                            {
                                Result.Add(1);
                            }
                            else
                            {
                                Result.Add(0);
                            }
                        }
                        else
                        {
                            if (SecretCodeDuplicateIndexesTwo.Contains(guessCodeIndex))
                            {
                                Result.Add(1);
                            }
                            else
                            {
                                Result.Add(0);
                            }
                        }
                        guess[guessCodeIndex] = 0;
                    }
                }
            }
            else if (DuplicatesValueGuess.Count > 0 && DuplicatesValueSecretCode.Count > 0)
            {
                List<List<int>> guessIndexesLists = new List<List<int>>()
                    {
                        GuessDuplicateIndexesOne,
                        GuessDuplicateIndexesTwo,
                     };
                List<List<int>> secretCodeIndexesLists = new List<List<int>>()
                    {
                        SecretCodeDuplicateIndexesOne,
                        SecretCodeDuplicateIndexesTwo,
                    };
                int guessIndex = -1;
                int secretCodeIndex = -1;
                int secretIndexCounter = -1;
                int guessIndexCounter = -1;
                int sameIndexEncountered = 0;
                DuplicatesMatchDetected = 0;
                DuplicatesInBothCodes = true;

                for (int i = 0; i < DuplicatesValueGuess.Count; i++)
                {
                    guessIndex++;//The value of guessIndex will serve as an index to indicate which list is being used in the guessIndexesLists. 0 = GuessDuplicateIndexesOne 1 =GuessDuplicateIndexesTwo
                    for (int j = 0; j < DuplicatesValueSecretCode.Count; j++)
                    {
                        secretCodeIndex++;//The value of secretCodeIndex will serve as an index to indicate which list is being used in the secretCodeIndexesLists. 0 = SecretCodeDuplicateIndexesOne 1 =SecretCodeDuplicateIndexesTwo
                        if (DuplicatesValueGuess[i] == DuplicatesValueSecretCode[j])//If the value in DuplicatesValueGuess is equal to the value in DuplicatesValueSecretCode
                        {
                            DuplicatesValueGuess[i] = 0;//If the number matches it will be set to 0.
                            DuplicatesMatchDetected++;//This will keep track of how many duplicates in the DuplicatesValueGuess matched with DuplicatesValueSecretCode.
                            for (int x = 0; x < guessIndexesLists[guessIndex].Count; x++)
                            {
                                guessIndexCounter++;
                                for (int y = 0; y < secretCodeIndexesLists[secretCodeIndex].Count; y++)
                                {
                                    secretIndexCounter++;
                                    if (guessIndexesLists[guessIndex][x] == secretCodeIndexesLists[secretCodeIndex][y])//If both indexes match
                                    {
                                        Result.Add(1);//Add 1 as a result
                                        guess[guessIndexesLists[guessIndex][x]] = 0;//Change the value in the guess to 0 
                                        sameIndexEncountered++;

                                        if (guessIndexCounter == guessIndexesLists[guessIndex].Count - 1)
                                        {
                                            if (DuplicatesAmountSecretCode[secretCodeIndex] <= DuplicatesAmountGuess[guessIndex])
                                            {
                                                for (int z = 0; z < secretCodeIndexesLists[secretCodeIndex].Count - sameIndexEncountered; z++)
                                                {
                                                    Result.Add(0);//add 0 to the result
                                                }
                                            }
                                            else
                                            {
                                                for (int z = 0; z < guessIndexesLists[guessIndex].Count - sameIndexEncountered; z++)
                                                {
                                                    Result.Add(0);//add 0 to the result
                                                }
                                            }
                                            break;//exit the loop
                                        }
                                    }
                                    else if (guessIndexesLists[guessIndex][x] != secretCodeIndexesLists[secretCodeIndex][y] && secretIndexCounter == secretCodeIndexesLists[secretCodeIndex].Count - 1)
                                    {
                                        guess[guessIndexesLists[guessIndex][x]] = 0;//Change the value in the guess to 0

                                        if (guessIndexCounter == guessIndexesLists[guessIndex].Count - 1)
                                        {
                                            if (DuplicatesAmountSecretCode[secretCodeIndex] <= DuplicatesAmountGuess[guessIndex])
                                            {
                                                for (int z = 0; z < secretCodeIndexesLists[secretCodeIndex].Count - sameIndexEncountered; z++)
                                                {
                                                    Result.Add(0);//add 0 to the result
                                                }
                                            }
                                            else
                                            {
                                                Result.Add(0);
                                            }
                                        }
                                    }
                                }
                                secretIndexCounter = -1;
                            }
                        }
                        guessIndexCounter = -1;
                        sameIndexEncountered = 0;
                    }
                    secretCodeIndex = -1;
                }
            }
            return guess;
        }
        private List<int> CheckNonMatchingDuplicatesForSingles(List<int> guess)
        {
            int secretCodeindex;
            bool indexMatch = false;

            List<List<int>> guessIndexesLists = new List<List<int>>()
                    {
                        GuessDuplicateIndexesOne,
                        GuessDuplicateIndexesTwo,
                     };
            List<List<int>> secretCodeIndexesLists = new List<List<int>>()
                    {
                        SecretCodeDuplicateIndexesOne,
                        SecretCodeDuplicateIndexesTwo,
                    };

            for (int x = 0; x < DuplicatesValueGuess.Count; x++)//Loop through each duplicate value of the guess code.
            {
                if (SecretCodes.Contains(DuplicatesValueGuess[x]))//if the secret code contains the value x in DuplicatesValueGuess.
                {
                    secretCodeindex = SecretCodes.IndexOf(DuplicatesValueGuess[x]);//Get the index of the number in the secret code and save it in secretCodeIndex Variable.

                    for (int index = 0; index < guessIndexesLists[x].Count; index++)//loop through GuessDuplicateIndexesOne and GuessDuplicateIndexesTwo to check if any of the indexes matches the secretCodeIndex.
                    {
                        if (guessIndexesLists[x][index] == secretCodeindex)//If a match is found set indexMatch to true and add 1 to the Result, then break the loop.
                        {
                            indexMatch = true;
                            Result.Add(1);
                            break;
                        }
                    }
                    if (!indexMatch)//If none of the indexes matched with the secretCodeIndex, add 0 to the result.
                    {
                        Result.Add(0);
                    }
                    foreach (int index in GuessDuplicateIndexesOne)//When all the guess duplicate indexes where checked, set the guess value of each index to 0.
                                                                   //Example guess =1244 duplicate indexes are 2,3.. guess value will change to 1200.
                    {
                        guess[index] = 0;
                    }
                    foreach (int index in GuessDuplicateIndexesTwo)
                    {
                        guess[index] = 0;
                    }
                }
            }
            return guess;
        }
    }
}
