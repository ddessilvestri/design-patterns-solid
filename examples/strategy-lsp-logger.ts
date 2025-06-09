/**
 * This example combines Strategy Pattern and Liskov Substitution Principle (LSP).
 * 
 * - Strategy is used to encapsulate interchangeable logging behaviors.
 * - LSP ensures that all LoggerStrategy implementations can be substituted safely
 *   without breaking the application.
 * 
 * Any class implementing LoggerStrategy can be used by LogService without special conditions.
 */

// Strategy interface
interface LoggerStrategy {
  log(message: string): void;
}

// Concrete strategies
class ConsoleLogger implements LoggerStrategy {
  log(message: string): void {
    console.log(`[Console] ${message}`);
  }
}

class FileLogger implements LoggerStrategy {
  log(message: string): void {
    // Simulate file write
    console.log(`[File] ${message} (written to file)`);
  }
}

class CloudLogger implements LoggerStrategy {
  log(message: string): void {
    console.log(`[Cloud] ${message} (sent to cloud service)`);
  }
}

// Context class using Strategy
class LogService {
  constructor(private logger: LoggerStrategy) {}

  writeLog(message: string): void {
    this.logger.log(message);
  }
}

// Usage
const service = new LogService(new ConsoleLogger());
service.writeLog("User logged in");

const fileService = new LogService(new FileLogger());
fileService.writeLog("File saved");

const cloudService = new LogService(new CloudLogger());
cloudService.writeLog("User analytics recorded");