def maxAreaOfFire(arr):
        maxSize=0
        row=len(arr)
        col=len(arr[0])
        
        for i in range(row):
            for j in range(col):
                if arr[i][j]==1:
                    curSize=check_forest(arr,i,j)
                    maxSize=max(maxSize,curSize)
        
        return maxSize
        
def check_forest(arr,i,j):    
    curArea = 0
    if i<0 or j<0 or i>=len(arr) or j>=len(arr[0]) or arr[i][j]==0:
        return curArea
    arr[i][j]=0 # clears it to make it no longer needed to check
    curArea = 1 # Found one
    curArea += check_forest(arr,i,j-1) # left
    curArea += check_forest(arr,i,j+1) # right
    curArea += check_forest(arr,i-1,j) # top
    curArea += check_forest(arr,i+1,j) # bottom
    return curArea

arr = [ [0,0,0,0,0,0],
        [0,0,1,0,0,0],
        [0,0,0,0,0,0],
        [0,0,1,1,0,0],
        [0,0,0,1,0,0],
        [0,0,1,1,0,0],
        [0,0,0,0,0,0]]

print(maxAreaOfFire(arr))