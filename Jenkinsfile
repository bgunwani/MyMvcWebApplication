pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Restore') {
            steps {
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build --configuration Release'
            }
        }

        stage('Test') {
            steps {
                bat 'dotnet test'
            }
        }

        stage('Publish') {
            steps {
                bat 'dotnet publish --configuration Release --output publish'
            }
        }

        stage('Docker Build') {
            steps {
                script {
                    sh 'docker build -t mymvcwebapplication .'
                }
            }
        }

        stage('Docker Run') {
            steps {
                script {
                    sh 'docker run -d -p 5000:80 --name mymvcapp-container mymvcwebapplication'
                }
            }
        }

        stage('Docker Test') {
            steps {
                script {
                    sh 'curl -f http://localhost:5000/health || exit 1' // Replace with actual health endpoint
                }
            }
        }
    }

    post {
        always {
            script {
                // Cleanup: Stop and remove the Docker container
                sh 'docker stop mymvcapp-container || true'
                sh 'docker rm mymvcapp-container || true'
            }
        }
    }
}
