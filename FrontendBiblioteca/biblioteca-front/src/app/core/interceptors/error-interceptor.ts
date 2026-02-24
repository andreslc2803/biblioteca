import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ErrorDialogComponent } from '../../shared/components/error-dialog/error-dialog';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const dialog = inject(MatDialog);

  return next(req).pipe(
    catchError((error) => {
      const backendMessage = error?.error?.Message || 'Ocurrió un error inesperado';
      dialog.open(ErrorDialogComponent, { data: backendMessage });
      return throwError(() => error);
    }),
  );
};
