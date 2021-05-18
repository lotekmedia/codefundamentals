
from collections import OrderedDict
import timeit

def removeDuplicates(arr):
	starttime = timeit.default_timer()
	print(list(set(arr)))
	setTime = str(timeit.default_timer() - starttime)
	starttime = timeit.default_timer()
	print(list(OrderedDict.fromkeys(arr)))
	dictTime = str(timeit.default_timer() - starttime)
	
	starttime = timeit.default_timer()
	prev = -1
	uniqueCount = 0
	for i in arr:
		if i != prev:
			arr[uniqueCount] = i
			uniqueCount += 1
		prev = i
	print(arr[:uniqueCount])
	prevTime = str(timeit.default_timer() - starttime)

	print('Set: ' + str(setTime))
	print('Ordered Dict: ' + str(dictTime))
	print('Prev Pointer: ' + str(prevTime))
	print('Fastest: ' + str(min(setTime,dictTime,prevTime)))

arr = [1,2,3,4,5,5,5,6,7,7,8]
removeDuplicates(arr)
