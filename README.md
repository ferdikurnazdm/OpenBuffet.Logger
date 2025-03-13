# Logger

```
 /$$                                                        
| $$                                                        
| $$        /$$$$$$   /$$$$$$   /$$$$$$   /$$$$$$   /$$$$$$ 
| $$       /$$__  $$ /$$__  $$ /$$__  $$ /$$__  $$ /$$__  $$
| $$      | $$  \ $$| $$  \ $$| $$  \ $$| $$$$$$$$| $$  \__/
| $$      | $$  | $$| $$  | $$| $$  | $$| $$_____/| $$      
| $$$$$$$$|  $$$$$$/|  $$$$$$$|  $$$$$$$|  $$$$$$$| $$      
|________/ \______/  \____  $$ \____  $$ \_______/|__/      
                     /$$  \ $$ /$$  \ $$                    
                    |  $$$$$$/|  $$$$$$/                    
                     \______/  \______/                     

```


## Description

This package ensure logging

## Getting Started

### Dependencies

* .NET Dependency Injection >=9.0.3

### Installing

* Install Library with Package Manager script or on Nuget GUI.

### Executing program
#### Usage
```
        IServiceProvider serviceProvider = new ServiceCollection()
            .AddOpenBuffetConsoleLogger()
            .AddOpenBuffetTextLogger(configuration => {
                configuration.Path = AppDomain.CurrentDomain.BaseDirectory;
            })
            .AddOpenBuffetJsonlLogger(configuration => {
                configuration.Path = AppDomain.CurrentDomain.BaseDirectory;
            })
            .AddOpenBuffetLoggerManager()
            .AddSingleton<Chronometer>()
            .BuildServiceProvider();
        var chronometer = serviceProvider.GetService<Chronometer>();
        while (true) { Thread.Sleep(1000); }
```
## Authors

Ferdi Kurnaz
[Contact](https://github.com/ferdikurnazdm/OpenBuffet.Logger)

## Version History

* 0.0
    * initial nuget package release

## License

This project is licensed under the [MIT] License


## Notes:



