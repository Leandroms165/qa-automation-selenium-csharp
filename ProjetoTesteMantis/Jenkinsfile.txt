pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/Leandroms165/qa-automation-selenium-csharp.git'
            }
        }

        stage('Restore dependencies') {
            steps {
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build --configuration Release'
            }
        }

        stage('Run Tests') {
            steps {
                bat 'dotnet test --configuration Release --no-build --logger "trx;LogFileName=test_results.trx"'
            }
        }
    }

    post {
        always {
            junit '**/TestResults/*.trx'
        }
    }
}
