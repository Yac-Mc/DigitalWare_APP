export class ResponseAPI {

  isSuccessful: boolean;
  statusCode: number;
  message: string;
  result: any;

  constructor(isSuccessful: boolean, statusCode: number, message: string, result: any) {
      this.isSuccessful = isSuccessful;
      this.statusCode = statusCode;
      this.message = message;
      this.result = result;
  }
}
