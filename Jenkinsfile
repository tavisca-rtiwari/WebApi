pipeline {
    agent any
    parameters {
                string(name: 'TEST_CSPROJ_PATH', defaultValue: 'WebApplicationApiTest/WebApplicationApi.test.csproj')
		string(name: 'WEBAPPLICATIONAPI_PATH', defaultValue: 'WebApplicationApi.sln')
		string(name: 'PROJECT_NAME', defaultValue: 'WebApplicationApi')
		string(name: 'DOCKER_USERNAME', defaultValue: 'rahubhopal')
		string(name: 'DOCKER_PASSWORD')
		string(name: 'DOCKER_REPO_NAME', defaultValue: 'web_application_api')
		string(name: 'SONAR_SCANNER_MSBUILD_PATH', defaultValue: 'C:/Users/rtiwari/Desktop/sonarscanner/SonarScanner.MSBuild.dll')
        string(name: 'SONAR_QUBE_PROJECT_KEY', defaultValue: 'webapi')
        string(name: 'SONAR_QUBE_TOKEN', defaultValue: '3977c2123ca9d06d16f619291bd5e634331ff2ad')

        }
    stages {
        stage('Build') {
            steps{
        bat '''
		    dotnet sonarscanner begin /k:"%SONAR_QUBE_PROJECT_KEY%" /d:sonar.login="%SONAR_QUBE_TOKEN%"                
            dotnet restore %WEBAPPLICATIONAPI_PATH% --source https://api.nuget.org/v3/index.json
            dotnet build %WEBAPPLICATIONAPI_PATH% -p:Configuration=release -v:n
            dotnet test %TEST_CSPROJ_PATH%
			dotnet %SONAR_SCANNER_MSBUILD_PATH% end /d:sonar.login="%SONAR_QUBE_TOKEN%" 
            dotnet publish %WEBAPPLICATIONAPI_PATH% -c Release
            docker build --tag=%DOCKER_USERNAME%/%DOCKER_REPO_NAME% --build-arg project_name=%PROJECT_NAME%.dll .
        '''}
        }
        stage('Deploy') {
            steps{
            bat '''
             docker login -u %DOCKER_USERNAME% -p %DOCKER_PASSWORD%
	     docker push %DOCKER_USERNAME%/%DOCKER_REPO_NAME%:latest
            '''
            }
        }
    }
}