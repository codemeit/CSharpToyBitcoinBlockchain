You may wonder how the mining works, this is the method tells the basic idea the condtition of 

     public void Mine(int difficulty)
     {
         // You mined successfully if you found a hash with certain number of leading '0's
         // difficulty defines the number of '0's required 
         // e.g. if difficulty is 2, if you found a hash like  00338500000x..., it means you mined it.
         while (this.Hash.Substring(0, difficulty) != new String('0', difficulty))
         {
             this._salt++;
             this.Hash = this.CalculateHash();
             Console.WriteLine("Mining:" + this.Hash);
         }

         Console.WriteLine("Block has been mined: " + this.Hash);
     }
	
Credits to SavjeeCoin who did this version in JavaScript
(Inspired by https://github.com/SavjeeTutorials/SavjeeCoin)