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
      string shortenedString = String.Empty;

      string tempWord = String.Empty; //store alphabetic word as built
      string wordFirstLetter = String.Empty; //keep first letter of real words
      string wordLastLetter = String.Empty; // keep last letter of real words
      string tempWordMid = String.Empty;

      string nonAlpha = String.Empty; //store non-alphabetic word as built

      bool buildingWord = false;

      Queue<string> words = new Queue<string>();
      Queue<string> nonWords = new Queue<string>();

      //Variable to track insertions word by word with boolean, 1 if word, 0 if not
      List<int> insertions = new List<int>();

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
          if (nonAlpha != ""){
            nonWords.Enqueue(nonAlpha);
            insertions.Add(0);

            // We're starting a new word, so keep the first character
            wordFirstLetter = c.ToString();
          }
          nonAlpha = "";
          tempWord += c.ToString();
          wordLastLetter = c.ToString();
        }
        else
        {
          // if word has been built, get #characters in middle, recombine chars & store result to list
          if (tempWord != ""){
            string wordToQueue = string.Format("{0}{1}{2}",wordFirstLetter.ToString(),tempWordMid.Distinct().ToString(),wordLastLetter.ToString());
            words.Enqueue(wordToQueue);
            insertions.Add(1);
            }

            tempWord = String.Empty;
            wordFirstLetter = String.Empty;
            wordLastLetter = String.Empty;
            tempWordMid = String.Empty;

            nonAlpha += c.ToString();
        }
      }

      // Recombine words & non-words
      for (int counter = 0; counter < insertions.Count(); counter++){
        string word = "";
        if(insertions[counter] == 0){
          shortenedString += nonWords.Dequeue();
        }
        else {
          shortenedString += words.Dequeue();
        }
      }

      // Return output
      return shortenedString;
    }
