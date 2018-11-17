using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Domain.Entities.BagEntity;
using Domain.Entities.ItemEntity;
using Runner.Algorithms;

namespace Algorithms.DynamicProgramming
{
    public class DynamicProgrammingAlgorithm : IOptimizationAlgorithm
    {
        private readonly IBagRepository _bagRepository;
        private readonly IItemRepository _itemRepository;

        public DynamicProgrammingAlgorithm(IBagRepository bagRepository, IItemRepository itemRepository)
        {
            _bagRepository = bagRepository;
            _itemRepository = itemRepository;
        }
        public void Optimize()
        {
            var bag = _bagRepository.GetBag();
            var items = _itemRepository.GetAllItems();
            
            var solutionMatrix = new SolutionMatrix(bag.RemainingCapacity + 1, items.Count);

            UpdateSolutionMatrix(items, bag, solutionMatrix);
            TraceBackSolution(bag, items, solutionMatrix);
        }

        private static void UpdateSolutionMatrix(List<Item> items, Bag bag, SolutionMatrix solutionMatrix)
        {
            for (int col = 0; col < items.Count; col++)
            {
                for (int row = 0; row <= bag.RemainingCapacity; row++)
                {
                    var item = items[col];

                    if (col == 0)
                    {
                        if (item.Weight <= row)
                        {
                            solutionMatrix.UpdateValue(row, col, item.Value);
                        }
                    }
                    else
                    {
                        if (item.Weight <= row)
                        {
                            int value = Math.Max(solutionMatrix.GetValue(row, col - 1),
                                item.Value + solutionMatrix.GetValue(row - item.Weight, col - 1));
                            solutionMatrix.UpdateValue(row, col, value);
                        }
                        else
                        {
                            solutionMatrix.UpdateValue(row, col, solutionMatrix.GetValue(row, col - 1));
                        }
                    }
                }
            }
        }

        private void TraceBackSolution(Bag bag, List<Item> items, SolutionMatrix solutionMatrix)
        {
            int row = bag.RemainingCapacity;
            for (int col = items.Count - 1; col >= 0; col--)
            {
                if (col == 0)
                {
                    if (solutionMatrix.GetValue(row, col) > 0)
                    {
                        _itemRepository.UpdateSolution(items[col]);
                        bag.UpdateSolution(items[col]);
                    }
                }
                else
                {
                    if (solutionMatrix.GetValue(row, col) != solutionMatrix.GetValue(row, col - 1))
                    {
                        _itemRepository.UpdateSolution(items[col]);
                        bag.UpdateSolution(items[col]);
                        row -= items[col].Weight;
                    }
                }
            }
        }
    }
}