using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpToyBitcoinBlockchain
{
    class Blockchain
    {
        // a chain has many blocks
        List<Block> _chain;
        public int Difficulty { get; set; }        

        public Blockchain()
        {
            this._chain = new List<Block>();
            this._chain.Add(CreateGenesisBlock());
            this.Difficulty = 2;
        }

        Block CreateGenesisBlock()
        {
            return new Block(0, "01/12/2017", "Genesis block", "");
        }

        public Block GetLatestBlock()
        {
            return this._chain.Last();
        }

        // Once a block is mined, add it to the block
        public void AddBlock(Block newBlock)
        {
            newBlock.PreviousHash = this.GetLatestBlock().Hash;
            newBlock.Mine(this.Difficulty);

            this._chain.Add(newBlock);
        }

        public void ValidateChain()
        {

            for (var i = 1; i < this._chain.Count; i++)
            {
                var currentBlock = this._chain[i];
                var previousBlock = this._chain[i - 1];

                // Check if the current block hash is consistent with the hash calculated
                if (currentBlock.Hash != currentBlock.CalculateHash())
                {
                    throw new Exception("Chain is not valid! Current hash is incorrect!");
                }

                // Check if the Previous hash match the hash of previous block
                if (currentBlock.PreviousHash != previousBlock.Hash)
                {
                    throw new Exception("Chain is not valid! PreviousHash isn't pointing to the previous block's hash!");
                }
            }            
        }
    }
}
