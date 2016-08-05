/*
 * Complete the function below.
 */

 /* Assumptions:
  1. Each word in the string is replaced with:
    - first letter of the word, then
    - count of distinct letters *between* first & last
    - last letter of word
    - Ex: Automotive = A6e
  2. A "word" is a sequence of alphabetic characters delimited by *non-alphabetic* characters
  3. Any non-alphabetic character in the input string should appear in the output string in its original relative location
  */


  static string shortenString(string input)
          {
              string shortenedString = string.Empty; // initialize shortened string
              try
              {
                  if (String.IsNullOrEmpty(input))
                  {
                      throw new System.ArgumentException("Invalid value", "input");
                  }
                  // Initialize variables
                  string tempWord = string.Empty; //store alphabetic word as built
                  string nonAlpha = string.Empty; //store non-alphabetic word as built

                  bool buildingWord = false;
                  char[] splitChars = { ' ' };
                  string[] inputWordsArray = input.Split(splitChars);
                  List<string> words = new List<string>();
                  foreach (string word in inputWordsArray)
                  {
                      // Iterate characters in input, sorting into words and non-words
                      foreach (char c in word)
                      {
                          if (Char.IsLetter(c))
                          {
                              buildingWord = true;
                          }
                          else
                          {
                              buildingWord = false;
                          }

                          if (buildingWord)
                          {
                              //if non-word has been built, store it
                              if (!String.IsNullOrEmpty(nonAlpha))
                              {
                                  words.Add(nonAlpha);
                                  tempWord = string.Empty;
                              }

                              nonAlpha = string.Empty;
                              if (String.IsNullOrEmpty(tempWord))
                              {
                                  tempWord = c.ToString();
                              }
                              else
                              {
                                  tempWord = string.Format("{0}{1}", tempWord, c.ToString());
                              }
                          }
                          else //buildingWord is false, so character was not alphabetic
                          {
                              // if word has been built, get # of characters in middle, recombine chars & store result to list
                              if (!String.IsNullOrEmpty(tempWord))
                              {
                                  string wordToAdd = string.Empty;
                                  char last = tempWord.Last(); // Get last char
                                  char first = tempWord.First(); // Get first char
                                  tempWord = tempWord.Substring(1,tempWord.Length - 2); // now the middle of the word
                                  int countOfDistinctLetters = tempWord.Distinct().Count();
                                  wordToAdd = string.Format("{0}{1}{2}", first.ToString(), countOfDistinctLetters.ToString(), last.ToString());

                                  words.Add(wordToAdd);
                                  nonAlpha = string.Empty;
                              }

                              tempWord = string.Empty;
                              if (String.IsNullOrEmpty(nonAlpha))
                              {
                                  nonAlpha = c.ToString();
                              }
                              else
                              {
                                  nonAlpha = string.Format("{0}{1}", nonAlpha, c.ToString());
                              }
                          }
                      }
                      // if only one word was loaded &  word has been built, get # of characters in middle, recombine chars & store result to list

                      if (!String.IsNullOrEmpty(tempWord))
                      {
                          string wordToAdd = string.Empty;
                          char last = tempWord.Last(); // Get last char
                          char first = tempWord.First(); // Get first char
                          tempWord = tempWord.Substring(1,tempWord.Length - 2); // now the middle of the word
                          int countOfDistinctLetters = tempWord.Distinct().Count();
                          wordToAdd = string.Format("{0}{1}{2}", first.ToString(), countOfDistinctLetters.ToString(), last.ToString());

                          words.Add(wordToAdd);
                          nonAlpha = string.Empty;
                      }

                      //if only one word was loaded and it was a non-word, store it
                      if (!String.IsNullOrEmpty(nonAlpha))
                      {
                          words.Add(nonAlpha);
                          tempWord = string.Empty;
                      }

                  }


                  // Recombine words & non-words
                  shortenedString = String.Join("", words);
                  //return shortenedString;

              }
              catch (Exception ex)
              {
                  // catch ex
              }

              // Return output
              return shortenedString;
          }
