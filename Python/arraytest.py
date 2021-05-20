'''
Input: 2d array of boolean
Output: number -> size of the largest potential fire

  Sample input (7 rows, 6 columns):
  -------------------------
  |   | T |   |   | T |   |
  -------------------------
  | T | T |   | T | T | T |
  -------------------------
  |   |   |   |   |   | T |
  -------------------------
  |   |   |   |   |   | T |
  -------------------------
  |   |   | T | T |   |   |
  -------------------------
  |   | T |   |   |   |   |
  -------------------------
  |   | T |   |   |   | T |
  -------------------------
  
  Output: 6
  
  
  Diagonals don't matter.  Count is maximum adjoining edges.  Ex: 6
  
  [[0,1,0,0,1,0],
   [1,1,0,1,1,1],
   [0,0,0,0,0,1],
   [0,0,0,0,0,1],
   [0,0,1,1,0,0],
   [0,1,0,0,0,0],
   [0,1,0,0,0,1]]
'''


def findCurMax(arr,x,y):
    cnt = 0
    cnt += findCurMax(arr,x+1,y)
    cnt += findCurMax(arr,x-1,y)
    cnt += findCurMax(arr,x,y+1)
    cnt += findCurMax(arr,x,y=1)
    if arr[x][y] == 1:
        return cnt += 1
    else:
        return 0


def findMaxFireArea(arr,x,y):
    inAlert = False
    for index,val in enumerate(arr):
        if val == 1:
            curSize = 1
            inAlert = True
            for index2, val2 in enumerate(val):
                if (index > 0):
                    top = val[index-1][index2]
                    curSize += findCurMax(arr,index-1,index2)
                    
                    right = val[index][index2+1]
                    curSize += findCurMax(arr,index-1,index2)
                    
                    bottom = val[index+1][index2]
                    curSize += findCurMax(arr,index-1,index2)
                    
                    left = val[index][index2-1]
                    curSize += findCurMax(arr,index-1,index2)
                if curSize > maxSize:
                    maxSize == curSize
    return maxSize

arr = [[0,1,0,0,1,0],
   [1,1,0,1,1,1],
   [0,0,0,0,0,1],
   [0,0,0,0,0,1],
   [0,0,1,1,0,0],
   [0,1,0,0,0,0],
   [0,1,0,0,0,1]]

print(findMaxFireArea(arr))


