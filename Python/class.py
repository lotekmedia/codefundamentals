class Dog:
    def __init__(self, breed):
        self.breed = breed

    @classmethod
    def walk(cls):
        print('Dog is Walking')

    # instance method
    def bark(self):
        print(f'{self.breed} is barking.')

    @staticmethod
    def add(x, y):
        return x + y


inst = Dog('Wolfhound')

inst.walk()
inst.bark()
print(inst.add(3, 5))
Dog.walk()
print(Dog.add(3, 4))
