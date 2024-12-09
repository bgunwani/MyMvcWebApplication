pipeline {
    agent any
    stages {
        stage('Restore') {
            steps {
                sh 'dotnet restore MyMvcWebApplication.sln'
            }
        }
        stage('Build') {
            steps {
                sh 'dotnet build MyMvcWebApplication.sln --configuration Release'
            }
        }
        stage('Test') {
            steps {
                sh 'dotnet test MyMvcWebApplication.sln --logger:trx'
            }
        }
        stage('Publish') {
            steps {
                sh 'dotnet publish MyMvcWebApplication.sln --configuration Release --output ./publish'
            }
        }
    }
}
