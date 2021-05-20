#!/bin/python3

import math
import os
import random
import re
import sys


def myFunction(name: str) -> str:
    return 'hello ' + name[len(name) - 1:1:-3]


#
# Complete the 'diagonalDifference' function below.
#
# The function is expected to return an INTEGER.
# The function accepts 2D_INTEGER_ARRAY arr as parameter.
#


def diagonalDifference(arr):
    # Write your code here
    arrDim = len(arr)
    sum1 = 0
    sum2 = 0
    for i in range(arrDim):
        sum1 += arr[i][i]
        sum2 += arr[arrDim - 1 - i][i]
    return abs(sum1 - sum2)


def staircase(n):
    # Write your code here
    # for i in range(1, n + 1):
    #     print(' ' * (n - i) + '#' * (i))

    #[print(("#" * x).rjust(n)) for x in range(1, n + 1)]
    for i in reversed(range(n)):
        print(' ' * i + '#' * (n - i))


def miniMaxSum(arr):
    # Write your code here
    arr.sort()
    minSum = 0
    maxSum = 0
    for num, i in enumerate(arr):
        if num == 0:
            minSum += i
        elif num == len(arr) - 1:
            maxSum += i
        else:
            maxSum += i
            minSum += i
    print(minSum, maxSum)


if __name__ == '__main__':
    #name = input('Enter your name: ')
    #print(myFunction('abcdefghijklmasdfasdfasdfasqweqwacdaf'))

    ## Diagonal
    #arr = [[11, 2, 4], [4, 5, 6], [10, 8, -12]]
    # for _ in range(n):
    #     arr.append(list(map(int, input().rstrip().split())))

    #result = diagonalDifference(arr)
    #print(result)

    ## Staircase
    #staircase(10)

    ## MinMax Sum
    miniMaxSum([5, 2, 3, 4, 1])
