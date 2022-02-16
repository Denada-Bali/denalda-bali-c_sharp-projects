# denalda-bali-c_sharp-projects

In this project is implemented a management system program of our university, University of New York Tirana. The program includes three main categories in the menu, which are: 
1. Student
2. Course 
3. Score

Each of the categories have three subcategories. 
# The Student category includes:
- Registration where we can register a new student, 
- Manage Student that updates the data for the students added,
- Print that prints the whole information in this category.  

#	The Course category includes:
- New Course where we can add a course 
- Manage Course that updates the information entered for the added course, 
- Print that prints the all the data regarded to the Course category. 

#	The Score category includes:
- New Score where we can enter new scores for a specific student
- Manage Scores that updates the scores entered
- Print that prints the information about the scores. 


# Reports

In the implementation of the program is used the MDI inheritance form. The program includes a splash screen in the beginning, and after it, the interface login which makes possible to enter the program, checks if an account is created or not. The account in login interface is connected with the database and gets all the data from the User table. So, the account is created directly from the database. 
The mainForm includes all the categories of the program. Here we can access all the information such as the total of the students registered at the university, the number of male and the number of female students, also the number of the students registered to specific courses just by searching the gender. Moreover, the categories are organized using #region and #endregion that can organize the code in blocks that extend or close the main category. 

Additionally, the subcategory Register, which is part of the category Student, consists of the name, last name, phone number, address, birthday, gender, and the photo of the student. Also, it includes even two buttons add and clear. Add button is to add a student in the list, whereas clear button is to automatically clear the data if the registration is canceled. This form also includes a DataGrid view to show the list of the registered students. The subcategory Manage Students is almost the same, apart from the text-box where we can search the students by their name, and also the text-box to enter the ID of the student in order to update the information. This form includes the buttons delete to delete the student and update the data, and clear to automatically delete the data. Furthermore, the interface Print consists of a DataGrid view that shows all the registered students with the relevant data. Also, there are three radio buttons1 that help to show in the DataGrid view the information of all the students (male, female), or just male students or female students. We can even just search by name only one student using text-box. The print button is for printing the information we need. 

The category Course consists of three subcategories as well. The function of the New Course subcategory is to register the courses of the university. To register a course, we need the name of the course, the course hours throughout all the semester and the description of the course, if it has a special requirement or prerequisite. It also contains the button add course and clear data. Manage Course includes a grid view that shows the courses already registered. The function of this interface is to update or to delete the courses that are already there. We can search the name of the course using a text-box which works like a search button. In addition, the subcategory Print shows all the registered courses, and by using a text-box we can search the course by its name. It also includes the button Print.  

At the category Score, the three subcategories of it are shown in the form of a block. The interface includes two buttons at the top of the page. The first shows the students registered in the Student category, and the other shows the grade of the students with the relevant course. To add the grade of the student we should enter the ID, select the course, enter the grade, then the letter grade. The two buttons add and clear are for adding a grade, and clearing an entered grade. Same process is followed at Manage Course subcategory too. To update the grading, we enter the ID, select the course, and enter the grade and the letter grade. We can search the course using the text-box. The button add is to add a grade, clear to automatically clear an entered grade, and update to update the whole grading data. Moreover, the Print subcategory shows the information of the student, the course and the grade in a DataGrid view. Also, is possible to search the student by entering the name. 

In the category list, are also included two other categories: Dashboard and Exit. The function of Dashboard is to converse the program in its initial form. Exit helps the user to exit the program and return to login interface to log in again.


# App Splash Screen 

![image](https://user-images.githubusercontent.com/86987951/154170376-baf79e62-f828-4976-a933-b5024781929e.png)

# Login Interface 

![image](https://user-images.githubusercontent.com/86987951/154171387-bc55f0ec-2d05-42f9-b719-48434472dda6.png)

# Dashboard 

![image](https://user-images.githubusercontent.com/86987951/154171745-1e55ba42-1f19-43e4-9615-07a8271428fd.png)

# Registration

![image](https://user-images.githubusercontent.com/86987951/154171892-765ea39b-f319-4d92-861f-5ed89e2968c2.png)

# Manage Students 

![image](https://user-images.githubusercontent.com/86987951/154172193-46a4b26c-a07e-475a-bee5-b72ef4abe2a7.png)

# Print 

![image](https://user-images.githubusercontent.com/86987951/154172451-51a60e5e-5325-46fe-9e60-e60728a4572b.png)

# New Course 

![image](https://user-images.githubusercontent.com/86987951/154172591-e64d670d-87b4-4104-9fcc-cd8d479829c5.png)

# Manage Course

![image](https://user-images.githubusercontent.com/86987951/154172659-60ec1fe1-f701-404e-8c50-7e56851dfed2.png)

# Print 

![image](https://user-images.githubusercontent.com/86987951/154172812-270fb61b-d09d-4b7d-b782-b4286c20c6aa.png)

# Score - Show Student 

  ![image](https://user-images.githubusercontent.com/86987951/154172944-daf8291c-6b89-4652-9dab-9cbeb8418d13.png)
  
# Score - Show Grade  
  ![image](https://user-images.githubusercontent.com/86987951/154173181-bb01e8f4-3e20-4fef-9c7e-869c173780ff.png)

# Manage Score

![image](https://user-images.githubusercontent.com/86987951/154173367-278d0ec4-97c3-47f1-832f-cc21b66b2f46.png)

# Print

![image](https://user-images.githubusercontent.com/86987951/154173303-0038b5b9-06c0-4156-908e-69bb2d3a5bee.png)


