class Graph():
    def __init__(self):
        self.graph = {}

    def addEdge(self, u, v):
        # Add empty list to key before appending (could use defaultdict to prevent key error also)
        if u not in self.graph:
            self.graph[u] = []
        self.graph[u].append(v)

    def isCyclicUtil(self, v, visited, recStack):
        # Mark current node as visited and
        # adds to recursion stack
        visited[v] = True
        recStack[v] = True

        # Recur for all neighbours
        # if any neighbour is visited and in
        # recStack then graph is cyclic
        for neighbour in self.graph[v]:
            if neighbour is not None:
                if visited[neighbour] == False:
                    if self.isCyclicUtil(neighbour, visited, recStack) == True:
                        return True
                elif recStack[neighbour] == True:
                    return True

        # The node needs to be poped from
        # recursion stack before function ends
        recStack[v] = False
        return False

    # Returns true if graph is cyclic else false
    def isCyclic(self):
        visited = {}
        recStack = {}
        for key in self.graph.keys():
            visited[key] = False
            recStack[key] = False
        for node in self.graph.keys():
            if visited[node] == False:
                if self.isCyclicUtil(node, visited, recStack) == True:
                    return True
        return False

    def find_path(self, start, end, path=[]):
        path = path + [start]
        if start == end:
            return path
        if start not in self.graph:
            return None
        for node in self.graph[start]:
            if node not in path:
                newpath = self.find_path(node, end, path)
                if newpath: return newpath
        return None


g = Graph()
g.addEdge('A', 'E')
g.addEdge('A', 'B')
g.addEdge('E', 'C')
g.addEdge('C', 'D')
g.addEdge('D', None)
g.addEdge('B', 'F')
g.addEdge('F', 'D')

if g.isCyclic():
    print('There is a cycle')
else:
    print('There is NOT a cycle')

print(g.find_path('A', 'D', []))
