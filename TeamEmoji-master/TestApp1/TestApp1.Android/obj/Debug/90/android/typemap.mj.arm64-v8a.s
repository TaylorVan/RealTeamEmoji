	/* Data SHA1: 021c4837c44092e9f38d1e13e6b76c0e9a3d3941 */
	.arch	armv8-a
	.file	"typemap.mj.inc"

	/* Mapping header */
	.section	.data.mj_typemap,"aw",@progbits
	.type	mj_typemap_header, @object
	.p2align	2
	.global	mj_typemap_header
mj_typemap_header:
	/* version */
	.word	1
	/* entry-count */
	.word	1154
	/* entry-length */
	.word	251
	/* value-offset */
	.word	143
	.size	mj_typemap_header, 16

	/* Mapping data */
	.type	mj_typemap, @object
	.global	mj_typemap
mj_typemap:
	.size	mj_typemap, 289655
	.include	"typemap.mj.inc"
