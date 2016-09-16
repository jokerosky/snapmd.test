using Snapmd.Core.Entities;
using Snapmd.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snapmd.Core.Solvers
{
    public class BilliardsTaskSolver : ITaskSolver
    {
        private int _jar1level;
        private int _jar2level;
        private bool _isPossible; 
        private int _targetValue;

        public TransfusionsResult TryToSolve(Jar first, Jar second, int targetValue)
        {
            var result = new TransfusionsResult
            {
                IsPossible = false,
                TransfusionsFirstWay = new List<Transfusion>(),
                TransfusionsSecondWay = new List<Transfusion>()
            };

            int max = GetMax(first, second);
            int min = GetMin(first, second);

            if(targetValue> max)
            {
                return result;
            }
            
            try
            {
                _jar1level = 0;
                _jar2level = 0;
                _targetValue = targetValue;
                
                //if we don`t want to show initial states comment them out
                //result.TransfusionsFirstWay.Add(new Transfusion(_jar1level, _jar2level));
                //result.TransfusionsSecondWay.Add(new Transfusion(_jar1level, _jar2level));

                // first way (set max as horizontal side of parallelogram)
                // jar 1 will be the biggest one;
                _jar1level = max;
                result.TransfusionsFirstWay.Add(new Transfusion(_jar1level, _jar2level));
                while (!IsFinished())
                {
                    if (_jar1level == max)
                    {
                        _jar1level = max - min + _jar2level;
                        _jar2level = min;
                        result.TransfusionsFirstWay.Add(new Transfusion(_jar1level, _jar2level));
                        if (IsFinished()) break;
                    }

                    if (_jar1level == 0)
                    {
                        _jar1level = max;
                        // _jar2level stays the same
                        result.TransfusionsFirstWay.Add(new Transfusion(_jar1level, _jar2level));
                    }

                    if (_jar2level == min)
                    {
                        // _jar1level  stays the same
                        _jar2level = 0;
                        result.TransfusionsFirstWay.Add(new Transfusion(_jar1level, _jar2level));
                    }

                    if (_jar2level == 0)
                    {
                        _jar2level = min > _jar1level ? _jar1level : _jar1level - min;
                        _jar1level = 0;
                        result.TransfusionsFirstWay.Add(new Transfusion(_jar1level, _jar2level));

                        if (IsFinished()) break;
                    }
                }

                _jar1level = 0;
                _jar2level = 0;

                // second way (set max as vertical side of parallelogram)
                // jar 1 will be the smallest one;
                _jar1level = min;
                result.TransfusionsSecondWay.Add(new Transfusion(_jar1level, _jar2level));
                while (!IsFinished())
                {
                    if (_jar1level == min)
                    {
                        _jar1level = max < _jar2level + min ? min - (max - _jar2level)  : 0;
                        _jar2level = max < _jar2level + min ? max : _jar2level + min;

                        result.TransfusionsSecondWay.Add(new Transfusion(_jar1level, _jar2level));
                        if (IsFinished()) break;
                    }

                    if (_jar2level == max)
                    {
                        _jar2level = 0;
                        // _jar1level stays the same
                        result.TransfusionsSecondWay.Add(new Transfusion(_jar1level, _jar2level));
                    }

                    if (_jar1level == 0)
                    {
                        // _jar1level  stays the same
                        _jar1level = min;
                        result.TransfusionsSecondWay.Add(new Transfusion(_jar1level, _jar2level));
                    }

                    if (_jar2level == 0)
                    {
                        _jar2level = _jar1level;
                        _jar1level = 0;
                        result.TransfusionsSecondWay.Add(new Transfusion(_jar1level, _jar2level));

                        if (IsFinished()) break;
                    }
                }

                result.IsPossible = true;
                return result;
            }
            catch(NoDecisionsException exp)
            {
                result.TransfusionsFirstWay = new List<Transfusion>();
                result.TransfusionsSecondWay = new List<Transfusion>();
                
                return result;
            }
        }

        private bool IsFinished()
        {
            if (_jar1level == 0 && _jar2level == 0) throw new NoDecisionsException($"No decision can be found for target value {_targetValue}.");
            return _jar1level == _targetValue || _jar2level == _targetValue;
        }

        /// <summary>
        /// if first Jar capacity >= than second max is 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>maximal capacity of the jar</returns>
        private int GetMax(Jar first, Jar second)
        {
            return first.Capacity >= second.Capacity ? first.Capacity : second.Capacity;
        }


        /// <summary>
        /// if first Jar capacity > than second min  is 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>maximal capacity of the jar</returns>
        private int GetMin(Jar first, Jar second)
        {
            return first.Capacity > second.Capacity ? second.Capacity : first.Capacity;
        }
    }
}
