pipeline {
    agent any
    tools {
        dotnet 'dotnet' // Ensure .NET SDK is installed and named in Jenkins
    }
    stages {
        stage('Clone Repository') {
            steps {
                checkout scm
            }
        }
        stage('Restore Dependencies') {
            steps {
                echo 'Restoring dependencies...'
                sh 'dotnet restore'
            }
        }
        stage('Build Application') {
            steps {
                echo 'Building the application...'
                sh 'dotnet build --configuration Release'
            }
        }
        stage('Run Unit Tests') {
            steps {
                echo 'Running unit tests...'
                sh 'dotnet test --no-build --verbosity normal'
            }
        }
        stage('Publish Application') {
            steps {
                echo 'Publishing the application...'
                sh 'dotnet publish --configuration Release --output ./publish'
            }
        }
        stage('Deploy Application') {
            steps {
                echo 'Deploying to target server...'
                // Deployment logic (e.g., SCP, FTP, Azure CLI)
                sh '''
                    # Example for deploying to a Linux server
                    scp -r ./publish user@server:/path/to/deploy
                '''
            }
        }
    }
    post {
        success {
            echo 'Pipeline completed successfully!'
        }
        failure {
            echo 'Pipeline failed.'
        }
    }
}
