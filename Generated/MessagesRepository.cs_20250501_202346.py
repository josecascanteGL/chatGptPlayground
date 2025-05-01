```python
# Python equivalent class code

class FileAnalyzer:
    def __init__(self, file_name):
        self.file_name = file_name

    def analyze_file(self):
        with open(self.file_name, 'r') as f:
            lines = f.readlines()
            num_lines = len(lines)
            num_words = sum(len(line.split()) for line in lines)
            num_chars = sum(len(line) for line in lines)
        
        print(f"Number of lines: {num_lines}")
        print(f"Number of words: {num_words}")
        print(f"Number of characters: {num_chars}")


# Usage
file_analyzer = FileAnalyzer("example.txt")
file_analyzer.analyze_file()
```