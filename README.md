# EmployeeSeriesManagemtApp

# Implementing Security to the Endpoints.

  1. In Azure portal setting the below information in Key Vault Service:
      - DB Connection String
      - Username and Passwords for the DB
      - Storing secrets used for JWT Token authentication
      - Storing Azure AD secret key
  
  2. Since this application is for internal employees, further security can be provided:

     - By using Azure AD authentication we only allow Azure AD users or Microsoft windows login users to be used for signing in to the
       application.
     - Azure AD can generate JWT token for authenticating the user request and we can also use refresh tokens to let users have 
       more convenience.
     - Creating a complex JWT token secret key.
     - Storing Jwt token in HttpOnly cookie.
     - Define and configure security policies in the program.cs file.
     - Enabling RBAC (Role based access control) and PBAC (Policy based access control).
     - While using Global Exception Handler, in case of exception, we can only display the error information, HttpStatusCode and, Request Path and
       preventing sensitive information or code from being displayed to the user.
     - We can secure our application if it is hosted in Azure by adding Network Security Group, Firewalls to protect from outside
       malicious access.            