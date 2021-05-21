#!/bin/python3

import math
import os
import random
import re
import sys


def binCount(dec):
    decimal = int(dec)
    binval = bin(decimal)
    val = str(binval[2:])
    # Prints equivalent decimal
    maxCount = 0
    curCount = 0
    for i in range(len(val)):
        if val[i] == '1':
            curCount += 1
        else:
            curCount = 0
        if curCount > maxCount:
            maxCount = curCount

    print(maxCount)


if __name__ == '__main__':
    n = int(input().strip())
    binCount(n)