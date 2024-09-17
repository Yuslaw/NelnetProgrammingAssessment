# Nelnet Coding Exercise

Please enhance this project with the following requirements:

## Requirement #1
Pets shall have a weight.  Use the following data for the existing test objects:

- Garfield: 20.0
- Odie: 15.0
- Peter Parker: 0.5
- Kaa: 25.0
- Nemo: 0.5
- Alpha: 0.1
- Splinter: 0.5
- Coco: 6.0
- Tweety: 0.05

## Requirement #2
Person shall have a prefered weight.  Weight classes are defined as:

- Extra Small: 0 < x <= 1.0
- Small: 1.0 < x <= 5.0
- Medium: 5.0 < x <= 15.0
- Large: 15.0 < x <= 30.0
- Extra Large: 30.0 < x

Use the following data for the existing test objects:

- Dalinar: Medium
- Kaladin: Extra Small

## Requirement #3
All preferences (classification, type, weight) shall be overridable, meaning each user can specify which characteristics they don't want in a pet.

## Requirement #4
A person shall be able to have unlimited number of overrides (i.e. a person might not want cats, snakes, fish or extra large pets)

## Requirement #5
Pet decisions shall be made using the following hierarchy (1 overrides 2, 2 overrides 3, etc.):

1. Type
2. Classification
3. Weight
4. Default Type/Classification/Weight on person object

For example, given Person A below:

```
{
  Name: 'Person A',
  PreferredClassification: PetClassification.Mammal,
  PreferredType: PetType.Cat
}
```

And Pet object:

```
{
  Name = "Odie",
  Classification = PetClassification.Mammal,
  Type = PetType.Dog
}
```

This would return as a good pet match because the user's preferred classification matches the pet's classification.  However, if Person A was opposed to dogs, we would want to be able to add an override for PetType.Dog so that this would no longer be a good match. 

You can choose how you would like to handle showing overrides (hard-code, accept user input, etc).  
The output of the program should list each pet for each person and whether the pet is a good match or a bad match.  Also, the listing per person should be sorted by "best" match to "worst" match (requirement #5).

