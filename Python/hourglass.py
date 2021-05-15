#!/bin/python3

import math
import os
import random
import re
import sys


# Complete the hourglassSum function below.
def hourglassSum(arr):
    currentMax = None
    for startArray in range(len(arr) - 2):
        for arrayPos in range(len(arr) - 2):
            newValue = arr[startArray][arrayPos] + arr[startArray][arrayPos +1] + arr[startArray][arrayPos + 2] \
                + arr[startArray + 1][arrayPos + 1] \
                + arr[startArray + 2][arrayPos] + arr[startArray + 2][arrayPos + 1] + arr[startArray + 2][arrayPos + 2]
            currentMax = newValue if currentMax is None or newValue > currentMax else currentMax
    return currentMax


if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    arr = []

    for _ in range(6):
        arr.append(list(map(int, input().rstrip().split())))

    result = hourglassSum(arr)

    fptr.write(str(result) + '\n')

    fptr.close()
