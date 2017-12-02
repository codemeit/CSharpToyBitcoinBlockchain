        static void Main(string[] args)
        {
            var myCoinBlockchain = new Blockchain();
            myCoinBlockchain.Difficulty = 3;

            // Received a block from the P2P network.
            // Validate 300 coins transfer.
            Console.WriteLine("Mining a block...");
            myCoinBlockchain.AddBlock(new Block(1, "03/12/2017", "300"));

            // this line below will cause the chain to be invalid.
            //myCoinBlockchain.GetLatestBlock().PreviousHash = "";

            // Validate the chain
            myCoinBlockchain.ValidateChain();
            

            Console.WriteLine("Done");
            Console.ReadKey();
        }
