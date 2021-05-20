#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'reverseArray' function below.
#
# The function is expected to return an INTEGER_ARRAY.
# The function accepts INTEGER_ARRAY a as parameter.
#


def reverseArray(a):
    # Write your code here
    result = []
    if len(a) > 0:
        result = a.reverse()
    print(a)
    return result


if __name__ == '__main__':
    fptr = open('test.txt', 'w')

    arr_count = int(input().strip())

    arr = list(map(int, input().rstrip().split()))
    res = reverseArray(arr)

    fptr.write(' '.join(map(str, res)))
    fptr.write('\n')

    fptr.close()
