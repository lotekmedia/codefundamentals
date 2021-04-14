class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        maxLength = start = 0
        mp = {}
        for i, value in enumerate(s):
            if value in mp:
                sums = mp[value] + 1
                if sums > start:
                    start = sums
            num = i - start + 1
            if num > maxLength:
                maxLength = num
            mp[value] = i
        print(mp)
        return maxLength


s = "dvdf"
sol = Solution()
print(sol.lengthOfLongestSubstring(s))