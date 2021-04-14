import timeit


def partition(arr, low, high):
    i = (low - 1)  # index of smaller element
    pivot = arr[high]  # pivot

    for j in range(low, high):

        # If current element is smaller than or
        # equal to pivot
        if arr[j] <= pivot:

            # increment index of smaller element
            i = i + 1
            arr[i], arr[j] = arr[j], arr[i]

    arr[i + 1], arr[high] = arr[high], arr[i + 1]
    return (i + 1)


def quickSort(arr, low, high):
    if len(arr) == 1:
        return arr
    if low < high:
        # pi is partitioning index, arr[p] is now
        # at right place
        pi = partition(arr, low, high)

        # Separately sort elements before
        # partition and after partition
        quickSort(arr, low, pi - 1)
        quickSort(arr, pi + 1, high)


def merge(left_list, right_list):
    sorted_list = []

    left_list_index = right_list_index = 0

    left_list_length, right_list_length = len(left_list), len(right_list)

    for x in range(left_list_length + right_list_length):
        if left_list_index < left_list_length and right_list_index < right_list_length:
            if left_list[left_list_index] <= right_list[right_list_index]:
                sorted_list.append(left_list[left_list_index])
                left_list_index += 1
            else:
                sorted_list.append(right_list[right_list_index])
                right_list_index += 1
        elif left_list_index == left_list_length:
            sorted_list.append(right_list[right_list_index])
            right_list_index += 1
        elif right_list_index == right_list_length:
            sorted_list.append(left_list[left_list_index])
            left_list_index += 1

    return sorted_list


def merge_sort(nums):
    if len(nums) <= 1:
        return nums

    mid = len(nums) // 2

    left_list = merge_sort(nums[:mid])
    right_list = merge_sort(nums[mid:])

    return merge(left_list, right_list)


arr = ['b', 'c', 'd', 'a', 'c', 'f', 'g']

starttime = timeit.default_timer()
print(merge_sort(arr))
mergeTime = str(timeit.default_timer() - starttime)

arr = ['b', 'c', 'd', 'a', 'c', 'f', 'g']
starttime = timeit.default_timer()
quickSort(arr, 0, len(arr) - 1)
print(arr)
quickTime = str(timeit.default_timer() - starttime)

print('Quicktime: ', quickTime)
print('MergeTime: ', mergeTime)
if quickTime < mergeTime:
    print('Quicksort was faster: ', quickTime)
elif quickTime > mergeTime:
    print('Merge Sort was faster: ', mergeTime)
else:
    print('Quick and Merge tied')
