using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpToyBitcoinBlockchain
{
    class Blockchain
    {

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

                if (currentBlock.Hash != currentBlock.CalculateHash())
                {
                    throw new Exception("Chain is not valid! Current hash is incorrect!");
                }

                if (currentBlock.PreviousHash != previousBlock.Hash)
                {
                    throw new Exception("Chain is not valid! PreviousHash isn't pointing to the previous block's hash!");
                }
            }            
        }
    }
}
