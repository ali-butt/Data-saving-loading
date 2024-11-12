# Data-saving-loading
Save your (Unity) game progress/data in local machine

# DataManager Script for Unity

This script provides a simple and efficient way to manage game data in Unity. It utilizes a `Dictionary<string, object>` to store key-value pairs, which can be easily added, modified, or removed at runtime. The data is serialized and saved to a file using `BinaryFormatter`, allowing it to persist across game sessions. You can also store and save custom classes as part of the data.

## Features:
- **Singleton Pattern**: Ensures only one instance of `DataManager` exists throughout the game session.
- **Data Persistence**: Automatically saves and loads game data from a file located in `Application.persistentDataPath`.
- **Flexible Data Management**: Allows for adding, modifying, and removing data stored in the dictionary.
- **Custom Class Support**: You can save and load custom classes, as long as they are marked as `[Serializable]`.
- **Error Handling**: Includes `try-catch` blocks to gracefully handle any issues during file I/O operations.

## Usage:
1. Attach the `DataManager` script to any GameObject in your Unity scene.
2. Access the `DataManager.instance` to modify or retrieve data.
3. Call `AddOrModifyData` to add new data or update existing data.
4. Use `Remove` to delete specific data.
5. The script automatically saves data when changes are made and loads it when the game starts.

## Example:

```csharp
// Example usage of the DataManager

// Add a simple data entry
DataManager.instance.AddOrModifyData("playerScore", 100);

// Access the saved data
int playerScore = (int)DataManager.instance.Data["playerScore"];

// Example of saving a custom class
[System.Serializable]
public class Player
{
    public string name;
    public int level;
    public float health;
}

// Create and save a custom Player object
Player player = new Player { name = "John", level = 1, health = 100f };
DataManager.instance.AddOrModifyData("player", player);

// Access the saved custom class
Player loadedPlayer = (Player)DataManager.instance.Data["player"];
