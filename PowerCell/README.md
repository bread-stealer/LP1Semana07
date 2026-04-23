```mermaid
classDiagram
    class Cell {
        - float charge
        + string Name
        + float Charge
        + int Level
        + Cell(string name)
        + void Consume(float amount)
        + void Restore()
        + string ToString()
    }