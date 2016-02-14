# Entity Framework

## 1. Conventions (with demo)
  - Code-First
  - Model-First
  - Database-First
  
### Demo (Superheroes)

#### Database Schema
  - Superhero
    - Name: string
    - IsOnMission: boolean
    - Skills: Array of Skill
    - Team: Array of Team
  - Skill
    - Name: string(50, required)
    - Value: int(required)
    - Description: string(500)
  - Team 
    - Name: string(50, required)
    - SuperHeroes: Array of Superhero
    
## 2. ApplicationContext implementation

- unit testing (ApplicationContext)
- create a new initializer (ApplicationDbInitializer)

## 3. Fluent API 

- why is it useful => different mapping in databases, can avoid attribute usages
- [**demo**] different ApplicationContext