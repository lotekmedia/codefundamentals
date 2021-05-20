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

maxRow = 0
maxCol = 0

def isSafe(arr, row, col) :
    # If row and column are valid and element 
    # is matched and hasn't been visited then 
    # the cell is safe 
    return ((row >= 0 and row < maxRow) and 
            (col >= 0 and col < maxCol) and 
            (arr[row][col] == 1 and not 
             visited[row][col]))

def DFS(arr, row, col) : 
  
    # These arrays are used to get row 
    # and column numbers of 4 neighbours 
    # of a given cell 
    rowNbr = [ -1, 1, 0, 0 ]
    colNbr = [ 0, 0, 1, -1 ]
  
    # Mark this cell as visited 
    visited[row][col] = True; 
    
    # Recur for all connected neighbours 
    if arr[row][col] == 1:
        curCount = 1
        for k in range(4) :
            if (isSafe(arr, row + rowNbr[k], col + colNbr[k])) :
                curCount += DFS(arr, row + rowNbr[k], col + colNbr[k])
                return 1
        return 1
    return 0

def findMaxSize(arr) :
    fireSize = 0; 
    for i in range(maxRow) :
        for j in range(maxCol) :
            if (not visited[i][j]) : 
                fireSize += DFS(arr, i, j)
                          
    return fireSize; 

arr = [[0,0,0,0,0,0],
       [0,0,1,1,0,0],
       [0,0,1,1,0,0],
       [0,0,1,1,0,0],
       [0,0,1,0,0,0],
       [0,0,1,0,0,0],
       [0,0,1,0,0,0]]

print(len(arr))
maxRow = len(arr)
maxCol = len(arr[0])
visited = [ [0]*maxCol for i in range(maxRow)]
print(findMaxSize(arr))


