
jQuery(function($) {

	"use strict";


	/**
	* Fileinput
	*/
	$("#form-register-photo").fileinput({
		dropZoneTitle: '<i class="fa fa-photo"></i><span>Upload Photo</span>',
		uploadUrl: '/',
		maxFileCount: 1,
		showUpload: false,
		browseLabel: 'Browse',
		browseIcon: '',
		removeLabel: 'Remove',
		removeIcon: '',
		uploadLabel: 'Upload',
		uploadIcon: '',
		autoReplace: true,
		showCaption: false,
		allowedFileTypes: ['image' ],
		allowedFileExtensions: ['jpg', 'gif', 'png', 'tiff'],
			initialPreview: [
				'<img src="/images/avatar.jpg" class="file-preview-image" alt="Avatar">',
		],
		overwriteInitial: true,
	});
	
	$("#form-register-photo-2").fileinput({
		dropZoneTitle: '<i class="fa fa-photo"></i><span>Upload Photo</span>',
		uploadUrl: '/',
		maxFileCount: 1,
		showUpload: false,
		browseLabel: 'Browse',
		browseIcon: '',
		removeLabel: 'Remove',
		removeIcon: '',
		autoReplace: true,
		showCaption: false,
		allowedFileTypes: ['image' ],
		allowedFileExtensions: ['jpg', 'gif', 'png', 'tiff'],
		overwriteInitial: true,
	});

	$("#form-photos").fileinput({
		dropZoneTitle: '<i class="fa fa-photo"></i><span>Upload Photos</span>',
		uploadUrl: '/',
		maxFileCount: 5,
		browseLabel: 'Browse',
		browseIcon: '',
		removeLabel: 'Remove',
		removeIcon: '',
		showUpload: false,
		uploadLabel: 'Upload',
		uploadIcon: '',
		autoReplace: false,
		showCaption: false,
		allowedFileTypes: ['image' ],
		allowedFileExtensions: ['jpg', 'gif', 'png', 'tiff'],
	});
	
	$("#input-ficons-3").fileinput({
		uploadUrl: "/",
		previewFileIcon: '<i class="fa fa-file"></i>',
		allowedPreviewTypes: ['image'], // allow only preview of image & text files
		previewFileIconSettings: {
				'docx': '<i class="fa fa-file-word-o text-primary"></i>',
				'xlsx': '<i class="fa fa-file-excel-o text-success"></i>',
				'pptx': '<i class="fa fa-file-powerpoint-o text-danger"></i>',
				'pdf': '<i class="fa fa-file-pdf-o text-danger"></i>',
				'zip': '<i class="fa fa-file-archive-o text-muted"></i>',
		},
		allowedFileExtensions: ['pdf', 'jpg', 'gif', 'png', 'tiff', 'doc', 'docx', 'zip', 'rar' ]
	});

	
	
});




