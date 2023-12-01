using System;
using System.ComponentModel.DataAnnotations;

namespace Life_Liberator.Models
{
    public class Project
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public required string Description { get; set; }

        public required ProficiencyLevel Difficulty { get; set; }

        public static Project[] InitializeProjects()
        {
            Project[] projects = new Project[24];
            Random rand = new Random();

            for (int i = 0; i < 24; i++)
            {
                Project project;

                if (i < 8)
                {
                    // 8 projects with Beginner difficulty
                    Project[] beginnerProjects = new Project[]
                    {
                        new Project {
                            Id = i + 1,
                            Title = "Guess The Letter Game",
                            Description = "In the language of your choosing complete the following: <br/> Generate the winning letter from A-Z and let the user choose any letter and tell the user if they need to search lower or higher in the alphabet, or if they are correct tell them they win.",
                            Difficulty = ProficiencyLevel.Beginner
                        },
                        new Project {
                            Id = i + 1,
                            Title = "Guess The Number Game",
                            Description = "In the language of your choosing complete the following: <br/> Generate the winning number from 1-25 and let the user choose any number and tell the user if they need to search lower or higher in the range, or if they are correct tell them they win.",
                            Difficulty = ProficiencyLevel.Beginner
                        },
                        new Project {
                            Id = i + 1,
                            Title = "Simple To-Do List Application",
                            Description = "Create a basic to-do list application that allows users to add, edit, and delete tasks. Include functionality to mark tasks as completed and filter tasks based on their status.",
                            Difficulty = ProficiencyLevel.Beginner
                        },
                        new Project {
                            Id = i + 1,
                            Title = "Calculator App",
                            Description = "Develop a simple calculator application that can perform basic arithmetic operations such as addition, subtraction, multiplication, and division. Enhance it by adding features like memory functions.",
                            Difficulty = ProficiencyLevel.Beginner
                        },
                        new Project {
                            Id = i + 1,
                            Title = "Random Quote Generator",
                            Description = "Build a program that displays a random quote every time it's run. You can store quotes in an array or fetch them from an external API. Allow users to refresh for a new quote.",
                            Difficulty = ProficiencyLevel.Beginner
                        },
                        new Project {
                            Id = i + 1,
                            Title = "Temperature Converter",
                            Description = "Create a program that converts temperatures between Fahrenheit and Celsius. Users should be able to input a temperature in one unit and get the converted value in the other.",
                            Difficulty = ProficiencyLevel.Beginner
                        },
                        new Project {
                            Id = i + 1,
                            Title = "Basic Web Scraping Tool",
                            Description = "Build a simple web scraping tool that extracts information from a website. You can choose a specific website or allow users to input a URL. Display the extracted data in a readable format.",
                            Difficulty = ProficiencyLevel.Beginner
                        },
                        new Project {
                            Id = i + 1,
                            Title = "Simple Blog Engine",
                            Description = "Develop a basic blog engine where users can create, edit, and delete blog posts. Include features like a list of all blog posts, individual post pages, and a comment section for each post.",
                            Difficulty = ProficiencyLevel.Beginner
                        },
                    };

                    project = beginnerProjects[i % 8];
                }
                else if (i < 16)
                {
                    // 8 projects with Intermediate difficulty
                    Project[] intermediateProjects = new Project[]
                    {
                        new Project {
                            Id = i + 1,
                            Title = "Stock Portfolio Tracker",
                            Description = "Develop a stock portfolio tracker that allows users to add, edit, and remove stocks from their portfolio. Implement features such as real-time stock price updates, performance analytics, and visualization of portfolio growth over time.",
                            Difficulty = ProficiencyLevel.Intermediate
                        },
                        new Project {
                            Id = i + 1,
                            Title = "Recipe Book with Search Functionality",
                            Description = "Create a recipe book application where users can add, edit, and search for recipes. Implement a search functionality based on ingredients, cuisine, or meal type. Include features such as recipe rating and comments.",
                            Difficulty = ProficiencyLevel.Intermediate
                        },
                        new Project {
                            Id = i + 1,
                            Title = "Task Management System with Notifications",
                            Description = "Build a task management system with features like task creation, due dates, and priority levels. Implement notifications to remind users of upcoming tasks. Allow users to categorize tasks and mark them as completed.",
                            Difficulty = ProficiencyLevel.Intermediate
                        },
                        new Project {
                            Id = i + 1,
                            Title = "Expense Tracker with Budgeting",
                            Description = "Develop an expense tracker that allows users to input and categorize their expenses. Implement budgeting features, charts, and graphs to help users visualize their spending habits. Provide insights into areas where users can save money.",
                            Difficulty = ProficiencyLevel.Intermediate
                        },
                        new Project {
                            Id = i + 1,
                            Title = "Weather App with API Integration",
                            Description = "Create a weather application that fetches real-time weather data from a public API. Allow users to search for weather information in different locations, view forecasts, and receive alerts for severe weather conditions.",
                            Difficulty = ProficiencyLevel.Intermediate
                        },
                        new Project {
                            Id = i + 1,
                            Title = "Collaborative Note-Taking App",
                            Description = "Build a collaborative note-taking application where multiple users can create, edit, and share notes in real-time. Implement user authentication and permission settings to control access to notes.",
                            Difficulty = ProficiencyLevel.Intermediate
                        },
                        new Project {
                            Id = i + 1,
                            Title = "Language Learning Flashcard Game",
                            Description = "Develop a flashcard game to help users learn a new language. Include features like customizable card sets, quizzes, and a scoring system to track users' progress. Integrate audio for pronunciation practice.",
                            Difficulty = ProficiencyLevel.Intermediate
                        },
                        new Project {
                            Id = i + 1,
                            Title = "Fitness Tracking App",
                            Description = "Create a fitness tracking application that allows users to log their workouts, set fitness goals, and track progress over time. Implement features like workout history, calorie tracking, and personalized workout recommendations.",
                            Difficulty = ProficiencyLevel.Intermediate
                        },
                    };


                    project = intermediateProjects[i % 8];
                }
                else
                {
                    // 8 projects with Advanced difficulty
                    Project[] advancedProjects = new Project[]
                    {
                        new Project {
                            Id = i + 1,
                            Title = "Sentiment Analysis Tool",
                            Description = "Build a sentiment analysis tool that analyzes text data and determines the sentiment (positive, negative, neutral). Use a pre-trained model or a simple algorithm to classify the sentiment of user-provided text.",
                            Difficulty = ProficiencyLevel.Advanced
                        },
                        new Project {
                            Id = i + 1,
                            Title = "Interactive Data Visualization Dashboard",
                            Description = "Create an interactive data visualization dashboard using a library like D3.js or Plotly. Import a dataset and display key insights through various charts and graphs. Allow users to explore and interact with the data.",
                            Difficulty = ProficiencyLevel.Advanced
                        },
                        new Project {
                            Id = i + 1,
                            Title = "Real-time Chat Application",
                            Description = "Develop a real-time chat application with features like instant messaging, user authentication, and message history. Use technologies such as WebSocket for real-time communication.",
                            Difficulty = ProficiencyLevel.Advanced
                        },
                        new Project {
                            Id = i + 1,
                            Title = "Task Automation Script",
                            Description = "Build a script that automates a repetitive task using a scripting language like Python. This could include file manipulation, data processing, or any other task that can be automated.",
                            Difficulty = ProficiencyLevel.Advanced
                        },
                        new Project {
                            Id = i + 1,
                            Title = "RESTful API for a Small Database",
                            Description = "Create a RESTful API that interacts with a small database (e.g., SQLite). Implement basic CRUD (Create, Read, Update, Delete) operations to manage data through HTTP requests.",
                            Difficulty = ProficiencyLevel.Advanced
                        },
                        new Project {
                            Id = i + 1,
                            Title = "Responsive Web Design with Flexbox or Grid",
                            Description = "Design and implement a responsive web page using CSS Flexbox or Grid. Ensure that the layout adjusts appropriately for different screen sizes, providing a seamless user experience.",
                            Difficulty = ProficiencyLevel.Advanced
                        },
                        new Project {
                            Id = i + 1,
                            Title = "Basic Machine Learning Model",
                            Description = "Train a simple machine learning model using a library like Scikit-Learn. Choose a beginner-friendly dataset and implement a basic model for classification or regression.",
                            Difficulty = ProficiencyLevel.Advanced
                        },
                        new Project {
                            Id = i + 1,
                            Title = "Geolocation-based Weather App",
                            Description = "Create a weather application that uses the user's geolocation to provide local weather information. Use a weather API to fetch real-time data and display it in a user-friendly format.",
                            Difficulty = ProficiencyLevel.Advanced
                        },
                    };


                    project = advancedProjects[i % 8];
                }

                projects[i] = project;
            }

            return projects;
        }
    }
}
