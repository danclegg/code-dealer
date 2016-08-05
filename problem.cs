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

  static string shortenString(string input) {
    // Initialize variables
    string shortenedString = string.Empty; // variable to keep entire return variable

    string tempWord = string.Empty; //store alphabetic word as built
    string nonAlpha = string.Empty; //store non-alphabetic word as built

    bool buildingWord = false;

    List<string> words = new List<string>();

    // Iterate characters in input, sorting into words and non-words
    foreach(char c in input){
      if (Char.IsLetter(c)){
        buildingWord = true;
      }
      else{
        buildingWord = false;
      }

      if(buildingWord){
        //if non-word has been built, store it
        if (!String.IsNullOrEmpty(nonAlpha)){
          words.Add(nonAlpha);
          tempWord = string.Empty;
        }

        nonAlpha = string.Empty;

        tempWord = String.Format("{0}{1}",tempWord,c.ToString());
      }
      else //buildingWord is false, so character was not alphabetic
      {
        // if word has been built, get # of characters in middle, recombine chars & store result to list
        if (!String.IsNullOrEmpty(tempWord)){
          string wordToAdd = string.Empty;
          int lengthOfWord = tempWord.Length;
          char last = tempWord.Last();
          char first = tempWord.First();
          string mid = tempWord.Substring(1, lengthOfWord - 2);
          int countOfDistinctLetters = mid.Distinct();
          wordToAdd = String.Format("{0}{1}{2}",first.ToString(),countOfDistinctLetters.ToString(),last.ToString());

          words.Add(wordToAdd);
          }

          tempWord = string.Empty;

          nonAlpha = String.Format("{0}{1}",nonAlpha,c.ToString());
      }
    }

    // Recombine words & non-words
    shortenedString = String.Join("",words);

    // Return output
    return shortenedString;
  }
