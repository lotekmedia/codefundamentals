import random
import timeit


class Node:
    def __init__(self, data=None):
        self.left = None
        self.right = None
        self.data = data

    def __str__(self):
        return '[' + str(self.data).strip() + ']'

    def insert(self, data):
        if self.data:
            if data < self.data:
                if self.left is None:
                    self.left = Node(data)
                else:
                    self.left.insert(data)
            elif data > self.data:
                if self.right is None:
                    self.right = Node(data)
                else:
                    self.right.insert(data)
        else:
            self.data = data

    def PreOrder(self, node):
        if (node is not None):
            print(node)
            self.PreOrder(node.left)
            self.PreOrder(node.right)

    def InOrder(self, node):
        if (node is not None):
            self.InOrder(node.left)
            print(node)
            self.InOrder(node.right)

    def PostOrder(self, node):
        if (node is not None):
            self.PostOrder(node.left)
            self.PostOrder(node.right)
            print(node)

    def PrintTree(self):
        if self.left:
            self.left.PrintTree()
        print(self),
        if self.right:
            self.right.PrintTree()

    def PrettyPrintTree(root):
        def display(node):
            """Returns list of strings, width, height, and horizontal coordinate of the root."""
            # No child.
            if node.right is None and node.left is None:
                line = str(node)
                width = len(line)
                height = 1
                middle = width // 2
                return [line], width, height, middle

            # Only left child.
            if node.right is None:
                lines, n, p, x = display(node.left)
                s = str(node)
                u = len(s)
                first_line = (x + 1) * ' ' + (n - x - 1) * '_' + s
                second_line = x * ' ' + '/' + (n - x - 1 + u) * ' '
                shifted_lines = [line + u * ' ' for line in lines]
                return [first_line, second_line
                        ] + shifted_lines, n + u, p + 2, n + u // 2

            # Only right child.
            if node.left is None:
                lines, n, p, x = display(node.right)
                s = str(node)
                u = len(s)
                first_line = s + x * '_' + (n - x) * ' '
                second_line = (u + x) * ' ' + '\\' + (n - x - 1) * ' '
                shifted_lines = [u * ' ' + line for line in lines]
                return [first_line, second_line
                        ] + shifted_lines, n + u, p + 2, u // 2

            # Two children.
            left, n, p, x = display(node.left)
            right, m, q, y = display(node.right)
            s = str(node)
            u = len(s)
            first_line = (x + 1) * ' ' + (n - x - 1) * '_' + s + y * '_' + (
                m - y) * ' '
            second_line = x * ' ' + '/' + (n - x - 1 + u +
                                           y) * ' ' + '\\' + (m - y - 1) * ' '
            if p < q:
                left += [n * ' '] * (q - p)
            elif q < p:
                right += [m * ' '] * (p - q)
            zipped_lines = zip(left, right)
            lines = [first_line, second_line
                     ] + [a + u * ' ' + b for a, b in zipped_lines]
            return lines, n + m + u, max(p, q) + 2, n + u // 2

        lines = display(root)
        for line in lines:
            print(line)


def main():
    import sys

    def readlines():
        for line in sys.stdin:
            yield line.strip('\n')

    #lines = readlines()
    tree = Node()
    for x in range(30):
        newVal = random.randint(0, 100)
        print(newVal)
        tree.insert(newVal)
    print('***')
    tree.PrintTree()
    print('\n***\n')
    tree.PrettyPrintTree()
    starttime = timeit.default_timer()
    tree.PreOrder(tree)
    preOrderTime = str(timeit.default_timer() - starttime)
    starttime = timeit.default_timer()
    tree.InOrder(tree)
    inOrderTime = str(timeit.default_timer() - starttime)
    starttime = timeit.default_timer()
    tree.PostOrder(tree)
    postOrderTime = str(timeit.default_timer() - starttime)
    print(preOrderTime + ':' + inOrderTime + ':' + postOrderTime)
    fastest = min(preOrderTime, postOrderTime, inOrderTime)
    if fastest == preOrderTime:
        print('PreOrder is the fastest')
    elif fastest == inOrderTime:
        print('InOrder is the fastest')
    else:
        print('PostOrder is the fastest')


if __name__ == '__main__':
    main()