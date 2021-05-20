class Solution:
    def maxAreaOfFire(self, arr):
        maxSize = 0
        self.row = len(arr)
        self.col = len(arr[0])

        for i in range(self.row):
            for j in range(self.col):
                if arr[i][j] == 1:
                    self.curSize = self.check_forest(arr, i, j)
                    maxSize = max(maxSize, self.curSize)

        return maxSize

    def check_forest(self, arr, i, j):
        curArea = 0
        if i < 0 or j < 0 or i >= len(arr) or j >= len(
                arr[0]) or arr[i][j] == 0:
            return curArea
        arr[i][j] = 0  # clears it to make it no longer needed to check
        curArea = 1  # Found one
        curArea += self.check_forest(arr, i, j - 1)  # left
        curArea += self.check_forest(arr, i, j + 1)  # right
        curArea += self.check_forest(arr, i - 1, j)  # top
        curArea += self.check_forest(arr, i + 1, j)  # bottom
        return curArea


arr = [[0, 1, 0, 0, 0, 0], [0, 1, 0, 1, 0, 0], [1, 1, 0, 1, 0, 1],
       [0, 0, 0, 1, 1, 1], [0, 0, 0, 0, 0, 0], [0, 1, 1, 0, 0, 0],
       [0, 1, 0, 0, 0, 0]]

inst = Solution()
print(inst.maxAreaOfFire(arr))
